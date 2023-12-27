using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.Controllers
{
    public class TestController : Controller
    {
        private readonly IServiceHousingService _serviceHousingService;

        public TestController(IServiceHousingService serviceHousingService)
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
            return View();
        }
        [HttpPost]
        public IActionResult AddServiceHousing(ServiceHousing serviceHousing)
        {
            _serviceHousingService.Insert(serviceHousing);
            return RedirectToAction("Index");
        }
    }
}
