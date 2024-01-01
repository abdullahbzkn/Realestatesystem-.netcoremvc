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
        private readonly IServiceMapService _serviceMapService;
        private readonly IServiceInfoService _serviceInfoService;
        private readonly IServiceHousingService _serviceHousingService;
        private readonly IServicePhotoService _servicePhotoService;
        private readonly REstateContext _context;
        ServiceInfo newServiceInfo;
      
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

        //    return View(viewModelList);
        //}

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


            //_serviceInfoService.Insert(new ServiceInfo
            //{
            //    EklenmeTarihi = DateTime.Now,
            //    GuncellenmeTarihi = DateTime.Now
            //});


            newServiceInfo = new ServiceInfo
            {
                EklenmeTarihi = DateTime.Now,
                GuncellenmeTarihi = DateTime.Now
            };


            ////serviceInfoManager.Insert(model.ServiceInfo);
            _serviceInfoService.Insert(newServiceInfo);


            model.ServiceHousing.ServiceMapId = model.ServiceMap.ServiceMapID;
            model.ServiceHousing.ServiceInfoId = newServiceInfo.ServiceInfoID;
            //serviceHousingManager.Insert(model.ServiceHousing);
            model.ServiceHousing.Status = true;
            _serviceHousingService.Insert(model.ServiceHousing);
            model.ServicePhoto.ServiceHousingId = model.ServiceHousing.ServiceHousingID;
            //model.ServicePhoto.ServiceTerrainId = model.ServiceHousing.ServiceTerrainID;

            //servicePhotoManager.Insert(model.ServicePhoto);
            _servicePhotoService.Insert(model.ServicePhoto);

            return RedirectToAction("Index");
        }

        //public IActionResult DeleteServiceHousing(int id)
        //{
        //    //var serviceHousing = serviceHousingManager.GetById(id);
        //    var serviceHousing = _serviceHousingService.GetById(id);
        //    //var serviceMap = serviceMapManager.GetById(serviceHousing.ServiceMapId ?? 0);
        //    var serviceMap = _serviceMapService.GetById(serviceHousing.ServiceMapId ?? 0);
        //    //var serviceInfo = serviceInfoManager.GetById(serviceHousing.ServiceInfoId ?? 0);
        //    var serviceInfo = _serviceInfoService.GetById(serviceHousing.ServiceInfoId ?? 0);
        //    //var servicePhoto = servicePhotoManager.GetByServiceHousingId(serviceHousing.ServiceHousingID);
        //    var servicePhoto = _servicePhotoService.GetByServiceHousingId(serviceHousing.ServiceHousingID);

        //    //serviceHousingManager.Delete(serviceHousing);
        //    _serviceHousingService.Delete(serviceHousing);
        //    //serviceMapManager.Delete(serviceMap);
        //    _serviceMapService.Delete(serviceMap);
        //    //serviceInfoManager.Delete(serviceInfo);
        //    _serviceInfoService.Delete(serviceInfo);
        //    //servicePhotoManager.Delete(servicePhoto);
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

            //// ServiceInfo güncelleme
            //var existingServiceInfo = _serviceInfoService.GetById(model.ServiceInfo.ServiceInfoID);

            //if (existingServiceInfo != null)
            //{
            //    existingServiceInfo.GuncellenmeTarihi = DateTime.Now;
            //    _serviceInfoService.Update(existingServiceInfo);
            //}


            //// ServiceInfo güncelleme
            //if (model.ServiceInfo == null)
            //{
            //    // Eğer ServiceInfo null ise, yeni bir ServiceInfo oluştur
            //    model.ServiceInfo = new ServiceInfo
            //    {
            //        EklenmeTarihi = DateTime.Now,
            //        GuncellenmeTarihi = DateTime.Now
            //    };
            //}
            //else
            //{
            //    // Eğer ServiceInfo null değilse, güncelleme işlemini yap
            //    var existingServiceInfo = _serviceInfoService.GetById(model.ServiceInfo.ServiceInfoID);

            //    if (existingServiceInfo != null)
            //    {
            //        existingServiceInfo.GuncellenmeTarihi = DateTime.Now;
            //        _serviceInfoService.Update(existingServiceInfo);
            //    }
            //}


            // ServiceInfo güncelleme
            var existingServiceInfo = _serviceInfoService.GetById(model.ServiceInfo.ServiceInfoID);

            if (existingServiceInfo != null)
            {
                existingServiceInfo.GuncellenmeTarihi = DateTime.Now;
                _serviceInfoService.Update(existingServiceInfo);
            }
            else
            {
                // Eğer ServiceInfo null değilse, güncelleme işlemini yap
                model.ServiceInfo.EklenmeTarihi = DateTime.Now;
                model.ServiceInfo.GuncellenmeTarihi = DateTime.Now;
                _serviceInfoService.Insert(model.ServiceInfo);
                existingServiceInfo = model.ServiceInfo; // Eklenen ServiceInfo'nun referansını al
            }



            //serviceInfoManager.Update(model.ServiceInfo);
            //_serviceInfoService.Update(model.ServiceInfo);
            model.ServiceHousing.ServiceMapId = model.ServiceMap.ServiceMapID;
            model.ServiceHousing.ServiceInfoId = existingServiceInfo.ServiceInfoID;
            //serviceHousingManager.Update(model.ServiceHousing);
            _serviceHousingService.Update(model.ServiceHousing);
            model.ServicePhoto.ServiceHousingId = model.ServiceHousing.ServiceHousingID;
            //servicePhotoManager.Update(model.ServicePhoto);
            _servicePhotoService.Update(model.ServicePhoto);

            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public IActionResult EditServiceHousing(ServiceHousingAddViewModel model)
        //{
        //    var existingServiceMap = _serviceMapService.GetById(model.ServiceMap.ServiceMapID);
        //    var existingServiceInfo = _serviceInfoService.GetById(model.ServiceInfo.ServiceInfoID);
        //    var existingServiceHousing = _serviceHousingService.GetById(model.ServiceHousing.ServiceHousingID);
        //    var existingServicePhoto = _servicePhotoService.GetByServiceHousingId(model.ServiceHousing.ServiceHousingID);

        //    existingServiceMap.Mahalle = model.ServiceMap.Mahalle;
        //    existingServiceMap.Koy = model.ServiceMap.Koy;
        //    existingServiceMap.Ilce = model.ServiceMap.Ilce;
        //    existingServiceMap.Il = model.ServiceMap.Il;

        //    if (existingServiceInfo != null)
        //    {
        //        existingServiceInfo.GuncellenmeTarihi = DateTime.Now;
        //    }
        //    else
        //    {
        //        model.ServiceInfo.EklenmeTarihi = DateTime.Now;
        //        model.ServiceInfo.GuncellenmeTarihi = DateTime.Now;
        //        _serviceInfoService.Insert(model.ServiceInfo);
        //        existingServiceHousing.ServiceInfoId = model.ServiceInfo.ServiceInfoID;
        //    }

        //    existingServiceHousing.Baslik = model.ServiceHousing.Baslik;
        //    existingServiceHousing.Gorsel = model.ServiceHousing.Gorsel;
        //    existingServiceHousing.Fiyat = model.ServiceHousing.Fiyat;
        //    existingServiceHousing.TapuDurumu = model.ServiceHousing.TapuDurumu;
        //    existingServiceHousing.YapininDurumu = model.ServiceHousing.YapininDurumu;
        //    existingServiceHousing.Isitma = model.ServiceHousing.Isitma;
        //    existingServiceHousing.BinaKatSayisi = model.ServiceHousing.BinaKatSayisi;
        //    existingServiceHousing.YapininCephesi = model.ServiceHousing.YapininCephesi;
        //    existingServiceHousing.YapininSekli = model.ServiceHousing.YapininSekli;
        //    existingServiceHousing.TuvaletSayisi = model.ServiceHousing.TuvaletSayisi;
        //    existingServiceHousing.BalkonSayisi = model.ServiceHousing.BalkonSayisi;
        //    existingServiceHousing.BanyoSayisi = model.ServiceHousing.BanyoSayisi;
        //    existingServiceHousing.SalonSayisi = model.ServiceHousing.SalonSayisi;
        //    existingServiceHousing.OdaSayisi = model.ServiceHousing.OdaSayisi;
        //    existingServiceHousing.KiraGetirisi = model.ServiceHousing.KiraGetirisi;
        //    existingServiceHousing.KullanimDurumu = model.ServiceHousing.KullanimDurumu;
        //    existingServiceHousing.YakitTipi = model.ServiceHousing.YakitTipi;
        //    existingServiceHousing.BulunduguKat = model.ServiceHousing.BulunduguKat;
        //    existingServiceHousing.Aidat = model.ServiceHousing.Aidat;
        //    existingServiceHousing.KonumLink = model.ServiceHousing.KonumLink;
        //    existingServiceHousing.UzunAciklama = model.ServiceHousing.UzunAciklama;
        //    existingServiceHousing.TakasYapilir = model.ServiceHousing.TakasYapilir;
        //    existingServiceHousing.KrediyeUygun = model.ServiceHousing.KrediyeUygun;
        //    existingServiceHousing.Devren = model.ServiceHousing.Devren;
        //    existingServiceHousing.Status = model.ServiceHousing.Status;

        //    existingServicePhoto.FotografYolu = model.ServicePhoto.FotografYolu;

        //    _serviceMapService.Update(existingServiceMap);
        //    _serviceInfoService.Update(existingServiceInfo);
        //    _serviceHousingService.Update(existingServiceHousing);
        //    _servicePhotoService.Update(existingServicePhoto);

        //    return RedirectToAction("Index");
        //}
        public IActionResult ChangeStatus(int id)
        {
            _serviceHousingService.ServiceHousingStatusToChange(id);
            return RedirectToAction("Index");
        }
        public IActionResult Deneme()
        {
            return View();
        }
    }
}
