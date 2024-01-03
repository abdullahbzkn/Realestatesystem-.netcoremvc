using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace REstatePresentation.ViewComponents
{
    public class _DashboardStatisticsPartial : ViewComponent
    {
        REstateContext c = new REstateContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.service = c.ServiceHousings.Count(item => item.Status == true)+ c.ServiceTerrains.Count(item => item.Status == true);
            ViewBag.price = c.ServiceHousings.Where(item => item.Status == true).Sum(item => item.Fiyat) + c.ServiceTerrains.Where(item => item.Status == true).Sum(item => item.Fiyat);
            ViewBag.visitors = c.VisitorCounters.Sum(item => item.Count);
            ViewBag.message = c.Contacts.Count();
            return View();
        }
    }
}
