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
    public class ServiceTerrainController : Controller
    {
        private readonly IServiceMapService _serviceMapService;
        private readonly IServiceInfoService _serviceInfoService;
        private readonly IServiceTerrainService _serviceTerrainService;
        private readonly IServicePhotoService _servicePhotoService;
        private readonly REstateContext _context;
        private ServiceInfo newServiceInfo;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ServiceTerrainController(
            IServiceMapService serviceMapService,
            IServiceInfoService serviceInfoService,
            IServiceTerrainService serviceTerrainService,
            IServicePhotoService servicePhotoService,
            REstateContext rEstateContext,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _serviceMapService = serviceMapService;
            _serviceInfoService = serviceInfoService;
            _serviceTerrainService = serviceTerrainService;
            _servicePhotoService = servicePhotoService;
            _context = rEstateContext;
            _webHostEnvironment = webHostEnvironment;
        }

       

        public IActionResult Index()
        {
            return View(_context.ServiceTerrains.Include(c => c.ServiceInfo).Include(c => c.ServicePhotos).Include(c => c.ServiceMap).ToList());
        }

        [HttpGet]
        public IActionResult AddServiceTerrain()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddServiceTerrain(ServiceTerrainAddViewModel model)
        {
            if (model.Photos == null || !model.Photos.Any())
            {
                ModelState.AddModelError("Photos", "En az bir fotoğraf seçmelisiniz.");
                return View(model); // Hata durumunda aynı view'i tekrar göster
            }
            //if (model.Gorsel == null || model.Gorsel.Length == 0)
            //{
            //    ModelState.AddModelError("Gorsel", "Bir görüntü seçmelisiniz.");
            //    return View(model);
            //}


            _serviceMapService.Insert(model.ServiceMap);

            newServiceInfo = new ServiceInfo
            {
                EklenmeTarihi = DateTime.Now,
                GuncellenmeTarihi = DateTime.Now
            };

            _serviceInfoService.Insert(newServiceInfo);
            model.ServiceTerrain.ServiceMapId = model.ServiceMap.ServiceMapID;
            model.ServiceTerrain.ServiceInfoId = newServiceInfo.ServiceInfoID;
            model.ServiceTerrain.Status = true;
               
            _serviceTerrainService.Insert(model.ServiceTerrain);
            //string gorselYolu;
            //var uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "upload");
            //var uniqFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Gorsel.FileName);
            //uniqFileName = uniqFileName.Replace(" ", "_");
            //uniqFileName = Uri.EscapeDataString(uniqFileName);
            //var filePt = Path.Combine(uploadFolder, uniqFileName);
            //model.Gorsel.CopyTo(new FileStream(filePt, FileMode.Create));
            //model.GorselYolu = "/upload/" + uniqFileName;
          
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
                        ServiceTerrainId = model.ServiceTerrain.ServiceTerrainID
                    };

                    _servicePhotoService.Insert(servicePhoto);
                    photoPaths.Add("/uploads/" + uniqueFileName);
                }
            }
            return RedirectToAction("Index");
        }
        
        public IActionResult DeleteServiceTerrain(int id)
        {
            var serviceTerrain = _serviceTerrainService.GetById(id);
            var serviceMap = _serviceMapService.GetById(serviceTerrain.ServiceMapId ?? 0);
            var serviceInfo = _serviceInfoService.GetById(serviceTerrain.ServiceInfoId ?? 0);
            var servicePhotos = _servicePhotoService.GetByServiceTerrainId(serviceTerrain.ServiceTerrainID);
            if (serviceTerrain == null)
            {
                return NotFound();
            }
            var existingServiceTerrain = _context.ServiceTerrains.AsNoTracking().FirstOrDefault(sh => sh.ServiceTerrainID == id);
            var existingServiceInfo = _context.ServiceInfos.AsNoTracking().FirstOrDefault(sh => sh.ServiceInfoID == serviceTerrain.ServiceInfoId);

            if (existingServiceTerrain != null && (existingServiceInfo.EklenmeTarihi != serviceInfo.EklenmeTarihi || existingServiceInfo.GuncellenmeTarihi != serviceInfo.GuncellenmeTarihi))
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

            _serviceTerrainService.Delete(serviceTerrain);

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
        public IActionResult EditServiceTerrain(int id)
        {
            var serviceTerrain = _serviceTerrainService.GetById(id);
            var serviceMap = _serviceMapService.GetById(serviceTerrain.ServiceMapId ?? 0);
            var serviceInfo = _serviceInfoService.GetById(serviceTerrain.ServiceInfoId ?? 0);
            var servicePhotos = _servicePhotoService.GetByServiceTerrainId(serviceTerrain.ServiceTerrainID);
            var photoPaths = servicePhotos.Select(photo => photo.FotografYolu).ToList();

            var model = new ServiceTerrainAddViewModel
            {
                ServiceTerrain = serviceTerrain,
                ServiceMap = serviceMap,
                ServiceInfo = serviceInfo,
                PhotoPaths = photoPaths
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult EditServiceTerrain(ServiceTerrainAddViewModel model)
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

            model.ServiceTerrain.ServiceMapId = model.ServiceMap.ServiceMapID;
            model.ServiceTerrain.ServiceInfoId = existingServiceInfo.ServiceInfoID;
            _serviceTerrainService.Update(model.ServiceTerrain);
            // Fotografları güncelleme
            var photoPaths = model.PhotoPaths;
            for (int i = 0; i < photoPaths.Count; i++)
            {
                var servicePhoto = new ServicePhoto
                {
                    FotografYolu = photoPaths[i],
                    ServiceTerrainId = model.ServiceTerrain.ServiceTerrainID
                };

                _servicePhotoService.Update(servicePhoto);
            }
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatus(int id)
        {
            _serviceTerrainService.ServiceTerrainStatusToChange(id);
            return RedirectToAction("Index");
        }
    }
}
