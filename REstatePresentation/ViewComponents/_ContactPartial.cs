using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.ViewComponents
{
    public class _ContactPartial: ViewComponent
    {
        private readonly IContactUsService _contactUsService;

        public _ContactPartial(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _contactUsService.GetListAll();
            return View(values);
        }
    }
}
