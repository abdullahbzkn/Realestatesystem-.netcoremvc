using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.ViewComponents
{
    public class _ContactPartial: ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
