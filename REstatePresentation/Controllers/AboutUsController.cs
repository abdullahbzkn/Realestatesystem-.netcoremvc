using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly IAboutUsService _aboutUsService;

        public AboutUsController(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }

        public IActionResult Index()
        {
            var values = _aboutUsService.GetListAll();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddAboutUs()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddAboutUs(AboutUs aboutUs)
        {
            _aboutUsService.Insert(aboutUs);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteAboutUs(int id)
        {
            var values = _aboutUsService.GetById(id);
            _aboutUsService.Delete(values);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditAboutUs(int id)
        {
            var values = _aboutUsService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditAboutUs(AboutUs aboutUs)
        {
            _aboutUsService.Update(aboutUs);
            return RedirectToAction("Index");
        }
    }
}
