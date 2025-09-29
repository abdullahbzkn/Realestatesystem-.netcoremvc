using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.ViewComponents
{
    public class _GalleryDescriptionPartial:ViewComponent
    {
        private readonly IGalleryService _galleryService;

        public _GalleryDescriptionPartial(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _galleryService.GetListAll();
            return View(values);
        }
    }
}
