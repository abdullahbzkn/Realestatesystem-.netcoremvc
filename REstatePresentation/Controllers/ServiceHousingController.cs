using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REstatePresentation.Models;
using System.ComponentModel;

namespace REstatePresentation.Controllers
{
    public class ServiceHousingController : Controller
    {
        private readonly IServiceMapService _serviceMapService;
        private readonly IServiceInfoService _serviceInfoService;
        private readonly IServiceHousingService _serviceHousingService;
        private readonly IServicePhotoService _servicePhotoService;
        private readonly REstateContext _context;
        private ServiceInfo newServiceInfo;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ServiceHousingController(
            IServiceMapService serviceMapService,
            IServiceInfoService serviceInfoService,
            IServiceHousingService serviceHousingService,
            IServicePhotoService servicePhotoService,
            REstateContext rEstateContext,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _serviceMapService = serviceMapService;
            _serviceInfoService = serviceInfoService;
            _serviceHousingService = serviceHousingService;
            _servicePhotoService = servicePhotoService;
            _context = rEstateContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(_context.ServiceHousings.Include(c => c.ServiceInfo).Include(c => c.ServicePhotos).Include(c => c.ServiceMap).ToList());
        }

        [HttpGet]
        public IActionResult AddServiceHousing()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddServiceHousing(ServiceHousingAddViewModel model)
        {
            if (model.Photos == null || !model.Photos.Any())
            {
                ModelState.AddModelError("Photos", "En az bir fotoğraf seçmelisiniz.");
                return View(model); // Hata durumunda aynı view'i tekrar göster
            }
            _serviceMapService.Insert(model.ServiceMap);

            newServiceInfo = new ServiceInfo
            {
                EklenmeTarihi = DateTime.Now,
                GuncellenmeTarihi = DateTime.Now
            };

            _serviceInfoService.Insert(newServiceInfo);
            model.ServiceHousing.ServiceMapId = model.ServiceMap.ServiceMapID;
            model.ServiceHousing.ServiceInfoId = newServiceInfo.ServiceInfoID;
            model.ServiceHousing.Status = true;
            _serviceHousingService.Insert(model.ServiceHousing);

            var photoPaths = new List<string>();

            foreach (var photo in model.Photos)
            {
                if (photo.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);
                    uniqueFileName = uniqueFileName.Replace(" ", "_");
                    uniqueFileName = Uri.EscapeDataString(uniqueFileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    var servicePhoto = new ServicePhoto
                    {
                        FotografYolu = "/uploads/" + uniqueFileName,
                        ServiceHousingId = model.ServiceHousing.ServiceHousingID
                    };

                    _servicePhotoService.Insert(servicePhoto);
                    photoPaths.Add("/uploads/" + uniqueFileName);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteServiceHousing(int id)
        {
            var serviceHousing = _serviceHousingService.GetById(id);
            var serviceMap = _serviceMapService.GetById(serviceHousing.ServiceMapId ?? 0);
            var serviceInfo = _serviceInfoService.GetById(serviceHousing.ServiceInfoId ?? 0);
            var servicePhotos = _servicePhotoService.GetByServiceHousingId(serviceHousing.ServiceHousingID);
            if (serviceHousing == null)
            {
                return NotFound();
            }
            var existingServiceHousing = _context.ServiceHousings.AsNoTracking().FirstOrDefault(sh => sh.ServiceHousingID == id);
            var existingServiceInfo = _context.ServiceInfos.AsNoTracking().FirstOrDefault(sh => sh.ServiceInfoID == serviceHousing.ServiceInfoId);

            if (existingServiceHousing != null && (existingServiceInfo.EklenmeTarihi != serviceInfo.EklenmeTarihi || existingServiceInfo.GuncellenmeTarihi != serviceInfo.GuncellenmeTarihi))
            {
                return View("ConcurrencyError");
            }

            // Fotoğraf yollarını ve dosyalarını silelim
            foreach (var photo in servicePhotos)
            {
                var photoPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", photo.FotografYolu);

                if (System.IO.File.Exists(photoPath))
                {
                    System.IO.File.Delete(photoPath);
                }

                _servicePhotoService.Delete(photo);
            }

            _serviceHousingService.Delete(serviceHousing);

            if (serviceMap != null)
            {
                _serviceMapService.Delete(serviceMap);
            }

            if (serviceInfo != null)
            {
                _serviceInfoService.Delete(serviceInfo);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditServiceHousing(int id)
        {
            var serviceHousing = _serviceHousingService.GetById(id);
            var serviceMap = _serviceMapService.GetById(serviceHousing.ServiceMapId ?? 0);
            var serviceInfo = _serviceInfoService.GetById(serviceHousing.ServiceInfoId ?? 0);
            var servicePhotos = _servicePhotoService.GetByServiceHousingId(serviceHousing.ServiceHousingID);
            var photoPaths = servicePhotos.Select(photo => photo.FotografYolu).ToList();


            var model = new ServiceHousingAddViewModel
            {
                ServiceHousing = serviceHousing,
                ServiceMap = serviceMap,
                ServiceInfo = serviceInfo,
                PhotoPaths = photoPaths
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult EditServiceHousing(ServiceHousingAddViewModel model)
        {
            _serviceMapService.Update(model.ServiceMap);

            // ServiceInfo güncelleme
            var existingServiceInfo = _serviceInfoService.GetById(model.ServiceInfo.ServiceInfoID);

            if (existingServiceInfo != null)
            {
                existingServiceInfo.GuncellenmeTarihi = DateTime.Now;
                _serviceInfoService.Update(existingServiceInfo);
            }
            else
            {
                model.ServiceInfo.EklenmeTarihi = DateTime.Now;
                model.ServiceInfo.GuncellenmeTarihi = DateTime.Now;
                _serviceInfoService.Insert(model.ServiceInfo);
                existingServiceInfo = model.ServiceInfo;
            }

            model.ServiceHousing.ServiceMapId = model.ServiceMap.ServiceMapID;
            model.ServiceHousing.ServiceInfoId = existingServiceInfo.ServiceInfoID;
            _serviceHousingService.Update(model.ServiceHousing);

            // Fotografları güncelleme
            var photoPaths = model.PhotoPaths;
            for (int i = 0; i < photoPaths.Count; i++)
            {
                var servicePhoto = new ServicePhoto
                {
                    FotografYolu = photoPaths[i],
                    ServiceTerrainId = model.ServiceHousing.ServiceHousingID
                };

                _servicePhotoService.Update(servicePhoto);
            }
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatus(int id)
        {
            _serviceHousingService.ServiceHousingStatusToChange(id);
            return RedirectToAction("Index");
        }
    }
}
