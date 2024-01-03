using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        public IActionResult Index()
        {
            var values = _galleryService.GetListAll();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddGallery()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddGallery(Gallery gallery)
        {
            _galleryService.Insert(gallery);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteGallery(int id)
        {
            var values = _galleryService.GetById(id);
            _galleryService.Delete(values);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditGallery(int id)
        {
            var values = _galleryService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditGallery(Gallery gallery)
        {
            _galleryService.Update(gallery);
            return RedirectToAction("Index");
        }
    }
}
