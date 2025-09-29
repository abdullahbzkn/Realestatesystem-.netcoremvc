using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.Controllers
{
    public class DashboardController : Controller
    {
      
        public IActionResult Index()
        {
            REstateContext c = new REstateContext();
            ViewBag.messagecount = c.Contacts.Count(item => item.OkunduBilgisi == false);

            var okunmamisMesajlar = c.Contacts
                .Where(item => item.OkunduBilgisi == false)
                .ToList();
            ViewBag.okunmamismesajlar = okunmamisMesajlar;
            return View();
        }
    }
}
