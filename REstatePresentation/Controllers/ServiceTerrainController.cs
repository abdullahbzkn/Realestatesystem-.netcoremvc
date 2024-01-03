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
    public class ServiceTerrainController : Controller
    {
        private readonly IServiceMapService _serviceMapService;
        private readonly IServiceInfoService _serviceInfoService;
        private readonly IServiceTerrainService _serviceTerrainService;
        private readonly IServicePhotoService _servicePhotoService;
        private readonly REstateContext _context;
        private ServiceInfo newServiceInfo;

        public ServiceTerrainController(
            IServiceMapService serviceMapService,
            IServiceInfoService serviceInfoService,
            IServiceTerrainService serviceTerrainService,
            IServicePhotoService servicePhotoService,
            REstateContext rEstateContext
            )
        {
            _serviceMapService = serviceMapService;
            _serviceInfoService = serviceInfoService;
            _serviceTerrainService = serviceTerrainService;
            _servicePhotoService = servicePhotoService;
            _context = rEstateContext;
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
            model.ServicePhoto.ServiceTerrainId = model.ServiceTerrain.ServiceTerrainID;
            _servicePhotoService.Insert(model.ServicePhoto);

            return RedirectToAction("Index");
        }

        
        public IActionResult DeleteServiceTerrain(int id)
        {
            var serviceTerrain = _serviceTerrainService.GetById(id);
            var serviceMap = _serviceMapService.GetById(serviceTerrain.ServiceMapId ?? 0);
            var serviceInfo = _serviceInfoService.GetById(serviceTerrain.ServiceInfoId ?? 0);
            var servicePhoto = _servicePhotoService.GetByServiceTerrainId(serviceTerrain.ServiceTerrainID);
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
            var servicePhoto = _servicePhotoService.GetByServiceTerrainId(serviceTerrain.ServiceTerrainID);

            var model = new ServiceTerrainAddViewModel
            {
                ServiceTerrain = serviceTerrain,
                ServiceMap = serviceMap,
                ServiceInfo = serviceInfo,
                ServicePhoto = servicePhoto
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

            model.ServicePhoto.ServiceTerrainId = model.ServiceTerrain.ServiceTerrainID;
            _servicePhotoService.Update(model.ServicePhoto);

            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatus(int id)
        {
            _serviceTerrainService.ServiceTerrainStatusToChange(id);
            return RedirectToAction("Index");
        }
    }
}
