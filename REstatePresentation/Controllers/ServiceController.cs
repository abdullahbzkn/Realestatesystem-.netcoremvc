using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using REstatePresentation.Models;

namespace REstatePresentation.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceHousingService _serviceHousingService;

        public ServiceController(IServiceHousingService serviceHousingService)
        {
            _serviceHousingService = serviceHousingService;
        }

        public IActionResult Index()
        {
            var values = _serviceHousingService.GetListAll();
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
                _serviceHousingService.Insert(new ServiceHousing()
                {
                    Baslik = model.Baslik,
                    Fiyat = model.Fiyat,
                    UzunAciklama = model.UzunAciklama
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
