using BusinessLayer.Abstract;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace REstatePresentation.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly REstateContext _context;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            REstateContext c = new REstateContext();
            ViewBag.messagecount = c.Contacts.Count(item => item.OkunduBilgisi == false);

            var okunmamisMesajlar = c.Contacts
                .Where(item => item.OkunduBilgisi == false)
                .ToList();
            ViewBag.okunmamismesajlar = okunmamisMesajlar;

            var values = _contactService.GetListAll();
            return View(values);
        }

        public IActionResult DeleteContact(int id)
        {
            var values = _contactService.GetById(id);
            _contactService.Delete(values);
            return RedirectToAction("Index");
        }

        public IActionResult ReadMessage(int id)
        {
            REstateContext c = new REstateContext();
            ViewBag.messagecount = c.Contacts.Count(item => item.OkunduBilgisi == false);

            var okunmamisMesajlar = c.Contacts
                .Where(item => item.OkunduBilgisi == false)
                .ToList();
            ViewBag.okunmamismesajlar = okunmamisMesajlar;


            var contact = c.Contacts.FirstOrDefault(c => c.ContactID == id);

            // Eğer contact bulunduysa ve OkunduBilgisi false ise güncelle
            if (contact != null && contact.OkunduBilgisi == false)
            {
                ChangeStatus(id);
            }

            var value = _contactService.GetById(id);
            return View(value);
        }

        public IActionResult ChangeStatus(int id)
        {
            _contactService.ContactStatusToChange(id);
            return RedirectToAction("Index");
        }
    }
}
