using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.ViewComponents
{
    public class _TopNavPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
