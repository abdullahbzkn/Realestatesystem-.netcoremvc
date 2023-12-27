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
        //private readonly IServiceHousingService _serviceHousingService;
        ServiceHousingManager serviceHousingManager = new ServiceHousingManager(new EfServiceHousingDal());


        //public ServiceController(IServiceHousingService serviceHousingService)
        //{
        //    _serviceHousingService = serviceHousingService;
        //}

        public IActionResult Index()
        {
            //var values = _serviceHousingService.GetListAll();
            var values = serviceHousingManager.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddServiceHousing()
        {
            return View(new ServiceHousingAddViewModel());
        }
        [HttpPost]
        public IActionResult AddServiceHousing(ServiceHousingAddViewModel model)
        {
            if(ModelState.IsValid)
            {
                //_serviceHousingService.Insert(new ServiceHousing()
                serviceHousingManager.Insert(new ServiceHousing()
                {
                    Baslik = model.Baslik,
                    Fiyat = model.Fiyat,
                    UzunAciklama = model.UzunAciklama
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteServiceHousing(int id)
        {
            var values = serviceHousingManager.GetById(id);
            serviceHousingManager.Delete(values);
            return RedirectToAction("Index");
        }
    }
}
