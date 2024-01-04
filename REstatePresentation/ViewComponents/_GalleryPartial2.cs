using BusinessLayer.Abstract;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace REstatePresentation.ViewComponents
{
    public class _GalleryPartial2: ViewComponent
    {
        private readonly IServiceTerrainService _serviceTerrainService;
        private readonly REstateContext _context;
        public _GalleryPartial2(IServiceTerrainService serviceTerrainService,REstateContext rEstateContext)
        {
            _serviceTerrainService = serviceTerrainService;
            _context = rEstateContext;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.ServiceTerrains.Include(c => c.ServiceInfo).Include(c => c.ServicePhotos).Include(c => c.ServiceMap).Where(r => r.Status == true).ToList());
        }
    }
}
