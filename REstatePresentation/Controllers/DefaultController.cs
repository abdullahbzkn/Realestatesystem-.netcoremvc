using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REstatePresentation.Models;

namespace REstatePresentation.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IServiceMapService _serviceMapService;
        private readonly IServiceInfoService _serviceInfoService;
        private readonly IServiceHousingService _serviceHousingService;
        private readonly IServiceTerrainService _serviceTerrainService;
        private readonly IServicePhotoService _servicePhotoService;
        private ServiceInfo newServiceInfo;
        private readonly IContactService _contactService;
        private readonly REstateContext _context;

        public DefaultController(
            IServiceMapService serviceMapService,
            IServiceInfoService serviceInfoService,
            IServiceHousingService serviceHousingService,
            IServiceTerrainService serviceTerrainService,
            IServicePhotoService servicePhotoService,
            IContactService contactService,
            REstateContext context)
        {
            _serviceMapService = serviceMapService;
            _serviceInfoService = serviceInfoService;
            _serviceHousingService = serviceHousingService;
            _serviceTerrainService = serviceTerrainService;
            _servicePhotoService = servicePhotoService;
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


        public IActionResult ServiceHousingDetails(int id)
        {
            var serviceHousing = _serviceHousingService.GetById(id);
            var serviceMap = _serviceMapService.GetById(serviceHousing.ServiceMapId ?? 0);
            var serviceInfo = _serviceInfoService.GetById(serviceHousing.ServiceInfoId ?? 0);
            var servicePhotos = _servicePhotoService.GetByServiceHousingId(serviceHousing.ServiceHousingID);
            var photoPaths = servicePhotos.Select(photo => photo.FotografYolu).ToList();

            var model = new ServiceHousingAddViewModel
            {
                ServiceHousing = serviceHousing,
                ServiceMap = serviceMap,
                ServiceInfo = serviceInfo,
                PhotoPaths = photoPaths,
                GorselYolu = serviceHousing.Gorsel
            };

            return View(model);
        }

        public IActionResult ServiceTerrainDetails(int id)
        {
            var serviceTerrain = _serviceTerrainService.GetById(id);
            var serviceMap = _serviceMapService.GetById(serviceTerrain.ServiceMapId ?? 0);
            var serviceInfo = _serviceInfoService.GetById(serviceTerrain.ServiceInfoId ?? 0);
            var servicePhotos = _servicePhotoService.GetByServiceTerrainId(serviceTerrain.ServiceTerrainID);
            var photoPaths = servicePhotos.Select(photo => photo.FotografYolu).ToList();

            var model = new ServiceTerrainAddViewModel
            {
                ServiceTerrain = serviceTerrain,
                ServiceMap = serviceMap,
                ServiceInfo = serviceInfo,
                PhotoPaths = photoPaths,
                GorselYolu = serviceTerrain.Gorsel
            };

            return View(model);
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
            contact.OkunduBilgisi = false;
            _contactService.Insert(contact);
            return RedirectToAction("Index","Default");
        }


        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
    }
}
