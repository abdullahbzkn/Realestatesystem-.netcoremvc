using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.ViewComponents
{
    public class _GalleryPartial: ViewComponent
    {
        private readonly IServiceHousingService _serviceHousingService;

        public _GalleryPartial(IServiceHousingService serviceHousingService)
        {
            _serviceHousingService = serviceHousingService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _serviceHousingService.GetListAll();
            return View(values);
        }
    }
}
