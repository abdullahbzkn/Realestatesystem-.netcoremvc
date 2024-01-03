using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _ContactUsService;

        public ContactUsController(IContactUsService ContactUsService)
        {
            _ContactUsService = ContactUsService;
        }

        public IActionResult Index()
        {
            var values = _ContactUsService.GetListAll();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddContactUs()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddContactUs(ContactUs ContactUs)
        {
            _ContactUsService.Insert(ContactUs);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteContactUs(int id)
        {
            var values = _ContactUsService.GetById(id);
            _ContactUsService.Delete(values);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditContactUs(int id)
        {
            var values = _ContactUsService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditContactUs(ContactUs ContactUs)
        {
            _ContactUsService.Update(ContactUs);
            return RedirectToAction("Index");
        }
    }
}
