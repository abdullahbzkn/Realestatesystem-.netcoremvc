using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.Controllers
{
    public class DefaultController : Controller
    {
        ServiceHousingManager serviceHousingManager = new ServiceHousingManager(new EfServiceHousingDal());
        public IActionResult Index()
        {
            var values = serviceHousingManager.GetListAll();
            return View(values);
        }
    }
}
