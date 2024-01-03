using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var values = _contactUsService.GetListAll();
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
            _contactUsService.Insert(ContactUs);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteContactUs(int id)
        {
            var values = _contactUsService.GetById(id);
            _contactUsService.Delete(values);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditContactUs(int id)
        {
            var values = _contactUsService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditContactUs(ContactUs ContactUs)
        {
            _contactUsService.Update(ContactUs);
            return RedirectToAction("Index");
        }
    }
}
