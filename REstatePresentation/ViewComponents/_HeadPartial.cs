using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.ViewComponents
{
    public class _HeadPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
