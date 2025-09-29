using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.ViewComponents
{
    public class _EntrancePartial:ViewComponent
    {
        private readonly IEntranceService _entranceService;

        public _EntrancePartial(IEntranceService entranceService)
        {
            _entranceService = entranceService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _entranceService.GetListAll();
            return View(values);
        }
    }
}
