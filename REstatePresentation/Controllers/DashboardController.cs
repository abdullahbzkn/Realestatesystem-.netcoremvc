using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
