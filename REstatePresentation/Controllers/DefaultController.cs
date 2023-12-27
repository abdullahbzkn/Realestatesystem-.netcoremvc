using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
