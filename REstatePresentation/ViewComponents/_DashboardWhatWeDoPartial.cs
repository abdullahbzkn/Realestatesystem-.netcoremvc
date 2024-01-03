using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.ViewComponents
{
    public class _DashboardWhatWeDoPartial: ViewComponent
    {

        private readonly IWhatWeDoService _whatWeDoService;

        public _DashboardWhatWeDoPartial(IWhatWeDoService whatWeDoService)
        {
            _whatWeDoService = whatWeDoService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _whatWeDoService.GetListAll();
            return View(values);
        }
    }
}
