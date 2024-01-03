using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.Controllers
{
    public class EntranceController : Controller
    {
        private readonly IEntranceService _entranceService;

        public EntranceController(IEntranceService entranceService)
        {
            _entranceService = entranceService;
        }

        public IActionResult Index()
        {
            var values = _entranceService.GetListAll();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddEntrance()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddEntrance(Entrance entrance)
        {
            _entranceService.Insert(entrance);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteEntrance(int id)
        {
            var values = _entranceService.GetById(id);
            _entranceService.Delete(values);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditEntrance(int id)
        {
            var values = _entranceService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditEntrance(Entrance entrance)
        {
            _entranceService.Update(entrance);
            return RedirectToAction("Index");
        }

    }
}
