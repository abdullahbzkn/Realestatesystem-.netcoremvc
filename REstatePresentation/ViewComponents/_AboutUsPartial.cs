using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.ViewComponents
{
    public class _AboutUsPartial : ViewComponent
    {
        private readonly IAboutUsService _aboutUsService;

        public _AboutUsPartial(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _aboutUsService.GetListAll();
            return View(values);
        }
    }
}
