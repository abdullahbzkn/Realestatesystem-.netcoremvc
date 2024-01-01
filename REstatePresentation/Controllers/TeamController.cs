using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace REstatePresentation.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var values = _teamService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            _teamService.Insert(team);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditTeam(Team team)
        {
            _teamService.Update(team);
            return RedirectToAction("Index");
        }
    }
}
