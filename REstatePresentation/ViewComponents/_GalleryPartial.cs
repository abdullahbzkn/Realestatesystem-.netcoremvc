using BusinessLayer.Abstract;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace REstatePresentation.ViewComponents
{
    public class _GalleryPartial: ViewComponent
    {
        private readonly IServiceHousingService _serviceHousingService;
        private readonly REstateContext _context;
        public _GalleryPartial(IServiceHousingService serviceHousingService,REstateContext rEstateContext)
        {
            _serviceHousingService = serviceHousingService;
            _context = rEstateContext;
        }

        public IViewComponentResult Invoke()
        {
         return View(_context.ServiceHousings.Include(c => c.ServiceInfo).Include(c => c.ServicePhotos).Include(c => c.ServiceMap).Where(r => r.Status == true).ToList());
        }
    }
}
