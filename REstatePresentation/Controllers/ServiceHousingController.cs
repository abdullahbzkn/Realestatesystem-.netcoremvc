using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using REstatePresentation.Models;
using System.ComponentModel;

namespace REstatePresentation.Controllers
{
    public class ServiceHousingController : Controller
    {
        ServiceHousingManager serviceHousingManager = new ServiceHousingManager(new EfServiceHousingDal());
        ServiceMapManager serviceMapManager = new ServiceMapManager(new EfServiceMapDal());
        ServicePhotoManager servicePhotoManager = new ServicePhotoManager(new EfServicePhotoDal());
        ServiceInfoManager serviceInfoManager = new ServiceInfoManager(new  EfServiceInfoDal());

        public IActionResult Index()
        {
            var values = serviceHousingManager.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddServiceHousing()
        {
            //ServiceHousingAddViewModel model = new ServiceHousingAddViewModel(); yeni otomatik oluştur
            //model.ServiceHousing.Baslik = "awda";
            //model.ServiceHousing.UzunAciklama = "awda";
            //model.ServiceHousing.Fiyat = 54;
            //model.ServiceMap.Koy = "jrfsj";
            //model.ServiceMap.Il = "jrfsj";
            //model.ServiceMap.Ilce = "jrfsj";
            //model.ServiceMap.Mahalle = "jrfsj";
            //model.ServicePhoto.FotografYolu = "jrfsSFSj";
            return View();
        }
        [HttpPost]
        public IActionResult AddServiceHousing(ServiceHousingAddViewModel model)
        {
            serviceMapManager.Insert(model.ServiceMap);
            serviceInfoManager.Insert(model.ServiceInfo);
            model.ServiceHousing.ServiceMapId = model.ServiceMap.ServiceMapID;
            model.ServiceHousing.ServiceInfoId = model.ServiceInfo.ServiceInfoID;
            serviceHousingManager.Insert(model.ServiceHousing);
            model.ServicePhoto.ServiceHousingId = model.ServiceHousing.ServiceHousingID;
            //model.ServicePhoto.ServiceTerrainId = model.ServiceHousing.ServiceTerrainID;
            servicePhotoManager.Insert(model.ServicePhoto);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteServiceHousing(int id)
        {
            var values = serviceHousingManager.GetById(id);
            serviceHousingManager.Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditServiceHousing(int id)
        {
            var values = serviceHousingManager.GetById(id);
            return RedirectToAction("Index");
        }

    }
}
