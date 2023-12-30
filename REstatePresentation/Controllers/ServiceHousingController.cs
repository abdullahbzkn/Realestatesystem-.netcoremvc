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
        //ServiceHousingManager serviceHousingManager = new ServiceHousingManager(new EfServiceHousingDal(),new REstateContext());
        //ServiceMapManager serviceMapManager = new ServiceMapManager(new EfServiceMapDal(), new REstateContext());
        //ServicePhotoManager servicePhotoManager = new ServicePhotoManager(new EfServicePhotoDal(), new REstateContext());
        //ServiceInfoManager serviceInfoManager = new ServiceInfoManager(new EfServiceInfoDal(), new REstateContext());


        //REstateContext rEstateContext = new REstateContext();
        private readonly IServiceHousingService _serviceHousingService;
        private readonly IServiceMapService _serviceMapService;
        private readonly IServicePhotoService _servicePhotoService;
        private readonly IServiceInfoService _serviceInfoService;
        private readonly REstateContext _context;

      
        public ServiceHousingController(
            IServiceHousingService serviceHousingService,
            IServiceMapService serviceMapService,
            IServicePhotoService servicePhotoService,
            IServiceInfoService serviceInfoService,
            REstateContext rEstateContext
            )
        {
            _serviceHousingService = serviceHousingService;
            _serviceMapService = serviceMapService;
            _servicePhotoService = servicePhotoService;
            _serviceInfoService = serviceInfoService;
            _context = rEstateContext;
        }

        public IActionResult Index()
        {
            //var values = serviceHousingManager.GetListAll();
            var values = _serviceHousingService.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddServiceHousing()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddServiceHousing(ServiceHousingAddViewModel model)
        {
            //serviceMapManager.Insert(model.ServiceMap);
            _serviceMapService.Insert(model.ServiceMap);
            //serviceInfoManager.Insert(model.ServiceInfo);
            _serviceInfoService.Insert(model.ServiceInfo);
            model.ServiceHousing.ServiceMapId = model.ServiceMap.ServiceMapID;
            model.ServiceHousing.ServiceInfoId = model.ServiceInfo.ServiceInfoID;
            //serviceHousingManager.Insert(model.ServiceHousing);
            _serviceHousingService.Insert(model.ServiceHousing);
            model.ServicePhoto.ServiceHousingId = model.ServiceHousing.ServiceHousingID;
            //model.ServicePhoto.ServiceTerrainId = model.ServiceHousing.ServiceTerrainID;

            //servicePhotoManager.Insert(model.ServicePhoto);
            _servicePhotoService.Insert(model.ServicePhoto);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteServiceHousing(int id)
        {
            //var serviceHousing = serviceHousingManager.GetById(id);
            var serviceHousing = _serviceHousingService.GetById(id);
            //var serviceMap = serviceMapManager.GetById(serviceHousing.ServiceMapId ?? 0);
            var serviceMap = _serviceMapService.GetById(serviceHousing.ServiceMapId ?? 0);
            //var serviceInfo = serviceInfoManager.GetById(serviceHousing.ServiceInfoId ?? 0);
            var serviceInfo = _serviceInfoService.GetById(serviceHousing.ServiceInfoId ?? 0);
            //var servicePhoto = servicePhotoManager.GetByServiceHousingId(serviceHousing.ServiceHousingID);
            var servicePhoto = _servicePhotoService.GetByServiceHousingId(serviceHousing.ServiceHousingID);

            //serviceHousingManager.Delete(serviceHousing);
            _serviceHousingService.Delete(serviceHousing);
            //serviceMapManager.Delete(serviceMap);
            _serviceMapService.Delete(serviceMap);
            //serviceInfoManager.Delete(serviceInfo);
            _serviceInfoService.Delete(serviceInfo);
            //servicePhotoManager.Delete(servicePhoto);
            _servicePhotoService.Delete(servicePhoto);

            //var serviceHousingToDelete = _context.ServiceHousings
            //.Include(sh => sh.ServicePhotos)
            //.Include(sh => sh.ServiceMap)
            //.Include(sh => sh.ServiceInfo)
            //.FirstOrDefault(sh => sh.ServiceHousingID == id);
            //if (serviceHousingToDelete != null)
            //{
            //    // ServiceHousing'a bağlı diğer verileri sil
            //    _context.ServicePhotos.RemoveRange(serviceHousingToDelete.ServicePhotos);
            //    _context.ServiceMaps.Remove(serviceHousingToDelete.ServiceMap);
            //    _context.ServiceInfos.Remove(serviceHousingToDelete.ServiceInfo);

            //    foreach (var servicePhoto in serviceHousingToDelete.ServicePhotos)
            //    {
            //        servicePhoto.ServiceHousing = null;
            //    }
            //    serviceHousingToDelete.ServiceMap = null;
            //    serviceHousingToDelete.ServiceInfo = null;

            //    // ServiceHousing'ı sil
            //    _context.ServiceHousings.Remove(serviceHousingToDelete);

            //    // Değişiklikleri kaydet
            //    _context.SaveChanges();
            //}


            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditServiceHousing(int id)
        {
            //var serviceHousing = serviceHousingManager.GetById(id);
            var serviceHousing = _serviceHousingService.GetById(id);
            //var serviceMap = serviceMapManager.GetById(serviceHousing.ServiceMapId ?? 0);
            var serviceMap = _serviceMapService.GetById(serviceHousing.ServiceMapId ?? 0);
            //var serviceInfo = serviceInfoManager.GetById(serviceHousing.ServiceInfoId ?? 0);
            var serviceInfo = _serviceInfoService.GetById(serviceHousing.ServiceInfoId ?? 0);
            //var servicePhoto = servicePhotoManager.GetByServiceHousingId(serviceHousing.ServiceHousingID);
            var servicePhoto = _servicePhotoService.GetByServiceHousingId(serviceHousing.ServiceHousingID);

            var model = new ServiceHousingAddViewModel
            {
                ServiceHousing = serviceHousing,
                ServiceMap = serviceMap,
                ServiceInfo = serviceInfo,
                ServicePhoto = servicePhoto
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult EditServiceHousing(ServiceHousingAddViewModel model)
        {
            //serviceMapManager.Update(model.ServiceMap);
            _serviceMapService.Update(model.ServiceMap);
            //serviceInfoManager.Update(model.ServiceInfo);
            _serviceInfoService.Update(model.ServiceInfo);
            model.ServiceHousing.ServiceMapId = model.ServiceMap.ServiceMapID;
            model.ServiceHousing.ServiceInfoId = model.ServiceInfo.ServiceInfoID;
            //serviceHousingManager.Update(model.ServiceHousing);
            _serviceHousingService.Update(model.ServiceHousing);
            model.ServicePhoto.ServiceHousingId = model.ServiceHousing.ServiceHousingID;
            //servicePhotoManager.Update(model.ServicePhoto);
            _servicePhotoService.Update(model.ServicePhoto);
            return RedirectToAction("Index");
        }

    }
}
