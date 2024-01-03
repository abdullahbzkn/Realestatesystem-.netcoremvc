using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace REstatePresentation.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IContactService _contactService;
        private readonly REstateContext _context;

        public DefaultController(IContactService contactService, REstateContext context)
        {
            _contactService = contactService;
            _context = context;
        }

        public IActionResult Index()
        {
            var counter = _context.VisitorCounters.FirstOrDefault();
            if (counter == null)
            {
                counter = new VisitorCounter { Count = 1 };
                _context.VisitorCounters.Add(counter);
            }
            else
            {
                counter.Count++;
                _context.Entry(counter).State = EntityState.Modified;
            }

            _context.SaveChanges();

            return View();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SendMessage(Contact contact)
        {
            contact.Date = DateTime.Now;
            _contactService.Insert(contact);
            return RedirectToAction("Index","Default");
        }


        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
    }
}
