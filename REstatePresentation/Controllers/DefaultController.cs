using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IServiceHousingService _serviceHousingService;
        public DefaultController(IServiceHousingService serviceHousingService)
        {
            _serviceHousingService = serviceHousingService;
        }
        //ServiceHousingManager serviceHousingManager = new ServiceHousingManager(new EfServiceHousingDal(), new EfServicePhotoDal(), new REstateContext());
        public IActionResult Index()
        {
            //var values = serviceHousingManager.GetListAll();
            var values = _serviceHousingService.GetListAll();
            return View(values);
            //return View();
        }
    }
}
