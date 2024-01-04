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

        public ServiceHousingController(
            IServiceMapService serviceMapService,
            IServiceInfoService serviceInfoService,
            IServiceHousingService serviceHousingService,
            IServicePhotoService servicePhotoService,
            REstateContext rEstateContext
            )
        {
            _serviceMapService = serviceMapService;
            _serviceInfoService = serviceInfoService;
            _serviceHousingService = serviceHousingService;
            _servicePhotoService = servicePhotoService;
            _context = rEstateContext;
        }

        //public IActionResult Index()
        //{
        //    var serviceHousingList = _serviceHousingService.GetListAll();
        //    var serviceTerrainList = _serviceTerrainService.GetListAll();
        //    var viewModelList = new List<ServiceHousingAddViewModel>();

        //    foreach (var serviceHousing in serviceHousingList)
        //    {
        //        var viewModel = new ServiceHousingAddViewModel
        //        {
        //            ServiceHousing = serviceHousing,
        //            // You may need to populate ServiceInfo property based on your application logic
        //            // ServiceInfo = PopulateServiceInfo(serviceHousing),
        //        };

        //        viewModelList.Add(viewModel);
        //    }
        //    foreach (var serviceTerrain in serviceTerrainList)
        //    {
        //        var viewModel2 = new ServiceHousingAddViewModel
        //        {
        //            ServiceTerrain = serviceTerrain,
        //            // ServiceInfo = PopulateServiceInfo(serviceTerrain),
        //        };

        //        viewModelList.Add(viewModel2);
        //    }

        //    return View(viewModelList);
        //}

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
            model.ServicePhoto.ServiceHousingId = model.ServiceHousing.ServiceHousingID;
            //model.ServicePhoto.ServiceTerrainId = model.ServiceHousing.ServiceTerrainID;

            //foreach (var file in model.FotoğrafYolu) buraya geri dönüş yapılacak
            //{
            //    // Dosyayı bir yere kaydet, örneğin sunucu klasörüne
            //    var filePath = Path.Combine("wwwroot/images", file.FileName);
            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        file.CopyTo(stream);
            //    }

            //    // Dosyanın yolu veya başka işlemleri veritabanına kaydet
            //    // ...
            //}


            _servicePhotoService.Insert(model.ServicePhoto);

            return RedirectToAction("Index");
        }

        //public IActionResult DeleteServiceHousing(int id)
        //{
        //    var serviceHousing = _serviceHousingService.GetById(id);
        //    var serviceMap = _serviceMapService.GetById(serviceHousing.ServiceMapId ?? 0);
        //    var serviceInfo = _serviceInfoService.GetById(serviceHousing.ServiceInfoId ?? 0);
        //    var servicePhoto = _servicePhotoService.GetByServiceHousingId(serviceHousing.ServiceHousingID);

        //    _serviceHousingService.Delete(serviceHousing);
        //    _serviceMapService.Delete(serviceMap);
        //    _serviceInfoService.Delete(serviceInfo);
        //    _servicePhotoService.Delete(servicePhoto);

        //    //var serviceHousingToDelete = _context.ServiceHousings
        //    //.Include(sh => sh.ServicePhotos)
        //    //.Include(sh => sh.ServiceMap)
        //    //.Include(sh => sh.ServiceInfo)
        //    //.FirstOrDefault(sh => sh.ServiceHousingID == id);
        //    //if (serviceHousingToDelete != null)
        //    //{
        //    //    // ServiceHousing'a bağlı diğer verileri sil
        //    //    _context.ServicePhotos.RemoveRange(serviceHousingToDelete.ServicePhotos);
        //    //    _context.ServiceMaps.Remove(serviceHousingToDelete.ServiceMap);
        //    //    _context.ServiceInfos.Remove(serviceHousingToDelete.ServiceInfo);

        //    //    foreach (var servicePhoto in serviceHousingToDelete.ServicePhotos)
        //    //    {
        //    //        servicePhoto.ServiceHousing = null;
        //    //    }
        //    //    serviceHousingToDelete.ServiceMap = null;
        //    //    serviceHousingToDelete.ServiceInfo = null;

        //    //    // ServiceHousing'ı sil
        //    //    _context.ServiceHousings.Remove(serviceHousingToDelete);

        //    //    // Değişiklikleri kaydet
        //    //    _context.SaveChanges();
        //    //}


        //    return RedirectToAction("Index");
        //}

        public IActionResult DeleteServiceHousing(int id)
        {
            var serviceHousing = _serviceHousingService.GetById(id);
            var serviceMap = _serviceMapService.GetById(serviceHousing.ServiceMapId ?? 0);
            var serviceInfo = _serviceInfoService.GetById(serviceHousing.ServiceInfoId ?? 0);
            var servicePhoto = _servicePhotoService.GetByServiceHousingId(serviceHousing.ServiceHousingID);
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

            _serviceHousingService.Delete(serviceHousing);

            if (serviceMap != null)
            {
                _serviceMapService.Delete(serviceMap);
            }

            if (serviceInfo != null)
            {
                _serviceInfoService.Delete(serviceInfo);
            }
            //if (servicePhoto != null)  photo zaten siliniyor
            //{
            //    _servicePhotoService.Delete(servicePhoto);
            //}
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditServiceHousing(int id)
        {
            var serviceHousing = _serviceHousingService.GetById(id);
            var serviceMap = _serviceMapService.GetById(serviceHousing.ServiceMapId ?? 0);
            var serviceInfo = _serviceInfoService.GetById(serviceHousing.ServiceInfoId ?? 0);
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

            model.ServicePhoto.ServiceHousingId = model.ServiceHousing.ServiceHousingID;
            _servicePhotoService.Update(model.ServicePhoto);

            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatus(int id)
        {
            _serviceHousingService.ServiceHousingStatusToChange(id);
            return RedirectToAction("Index");
        }
    }
}
