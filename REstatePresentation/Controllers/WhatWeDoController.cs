using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.Controllers
{
    public class WhatWeDoController : Controller
    {
        private readonly IWhatWeDoService _whatWeDoService;

        public WhatWeDoController(IWhatWeDoService whatWeDoService)
        {
            _whatWeDoService = whatWeDoService;
        }

        public IActionResult Index()
        {
            var values = _whatWeDoService.GetListAll();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddWhatWeDo()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddWhatWeDo(WhatWeDo whatWeDo)
        {
            _whatWeDoService.Insert(whatWeDo);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteWhatWeDo(int id)
        {
            var values = _whatWeDoService.GetById(id);
            _whatWeDoService.Delete(values);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditWhatWeDo(int id)
        {
            var values = _whatWeDoService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditWhatWeDo(WhatWeDo whatWeDo)
        {
            _whatWeDoService.Update(whatWeDo);
            return RedirectToAction("Index");
        }

    }
}
