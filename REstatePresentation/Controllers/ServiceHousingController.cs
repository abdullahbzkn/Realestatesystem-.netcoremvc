using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using REstatePresentation.Models;
using System.ComponentModel;
using System.Linq;
using System.IO;


namespace REstatePresentation.Controllers
{
    public class ServiceHousingController : Controller
    {
        private readonly IServiceMapService _serviceMapService;
        private readonly IServiceInfoService _serviceInfoService;
        private readonly IServiceHousingService _serviceHousingService;
        private readonly IServicePhotoService _sservicePhotoService;
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
            _sservicePhotoService = servicePhotoService;
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
                return View(model);
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

            var photoPathss = new List<string>();

            foreach (var photo in model.Photos)
            {
                if (photo.Length > 0)
                {
                    var uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    var uniquFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);
                    uniquFileName = uniquFileName.Replace(" ", "_");
                    uniquFileName = Uri.EscapeDataString(uniquFileName);
                    var filPath = Path.Combine(uploadFolder, uniquFileName);
                    photo.CopyTo(new FileStream(filPath, FileMode.Create));
                    var servicPhoto = new ServicePhoto
                    {
                        FotografYolu = "/uploads/" + uniquFileName,
                        ServiceHousingId = model.ServiceHousing.ServiceHousingID
                    };

                    _sservicePhotoService.Insert(servicPhoto);
                    photoPathss.Add("/uploads/" + uniquFileName);
                }
            }
            var firstPhoto = photoPathss[0];
            model.ServiceHousing.Gorsel = firstPhoto;
            _serviceHousingService.Update(model.ServiceHousing);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteServiceHousing(int id)
        {
            var serviceHousing = _serviceHousingService.GetById(id);
            var serviceMap = _serviceMapService.GetById(serviceHousing.ServiceMapId ?? 0);
            var serviceInfo = _serviceInfoService.GetById(serviceHousing.ServiceInfoId ?? 0);
            var servicePhotos = _sservicePhotoService.GetByServiceHousingId(serviceHousing.ServiceHousingID);
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

            foreach (var photo in servicePhotos)
            {
                var photoPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", photo.FotografYolu);

                if (System.IO.File.Exists(photoPath))
                {
                    System.IO.File.Delete(photoPath);
                }

                _sservicePhotoService.Delete(photo);
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
            var servicePhotoss = _sservicePhotoService.GetByServiceHousingId(serviceHousing.ServiceHousingID);
            var photoPathss = servicePhotoss.Where(photo => photo.ServiceTerrainId == null).Where(photo => photo.ServiceHousingId == id).Select(photo => photo.FotografYolu).ToList();

            var model = new ServiceHousingAddViewModel
            {
                ServiceHousing = serviceHousing,
                ServiceMap = serviceMap,
                ServiceInfo = serviceInfo,
                PhotoPaths = photoPathss,
                GorselYolu = serviceHousing.Gorsel
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

            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatus(int id)
        {
            _serviceHousingService.ServiceHousingStatusToChange(id);
            return RedirectToAction("Index");
        }
    }
}
