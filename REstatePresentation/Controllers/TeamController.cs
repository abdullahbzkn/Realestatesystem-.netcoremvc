using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using REstatePresentation.Models;
using System.Linq;
using System.IO;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace REstatePresentation.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly REstateContext _context;



        public TeamController(
            ITeamService teamService,
            IWebHostEnvironment webHostEnvironment,
            REstateContext context)
        {
            _teamService = teamService;
           _webHostEnvironment = webHostEnvironment;
            _context = context;
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
        public IActionResult AddTeam(TeamAddViewModel model)
        {
            if (model.Gorsel != null)
            {
                TeamValidator validationRules = new TeamValidator();
                ValidationResult result = validationRules.Validate(model.Team);
                if (result.IsValid)
                {
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Gorsel.FileName);
                uniqueFileName = uniqueFileName.Replace(" ", "_");
                uniqueFileName = Uri.EscapeDataString(uniqueFileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.Gorsel.CopyTo(new FileStream(filePath, FileMode.Create));
                model.GorselYolu = "/uploads/" + uniqueFileName;
                model.Team.FotografYolu = model.GorselYolu;
                _teamService.Insert(model.Team);
                return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }

            }
            else
            {
                ModelState.AddModelError("Gorsel", "Bir fotoğraf seçmelisiniz.");
                return View(model);

            }


            return View();
        }

        public IActionResult DeleteTeam(int id)
        {
            var team = _teamService.GetById(id);
            if (team == null)
            {
                return NotFound();
            }

            var existingTeam = _context.Teams.AsNoTracking().FirstOrDefault(sh => sh.TeamID == id);


            var gorselYolu = Path.Combine(_webHostEnvironment.WebRootPath, team.FotografYolu);
            Console.WriteLine(gorselYolu);

            if (System.IO.File.Exists(gorselYolu))
            {
                System.IO.File.Delete(gorselYolu);
            }

            _teamService.Delete(team);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditTeam(int id)
        {
            var values = _teamService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditTeam(TeamAddViewModel model)
        {
            TeamValidator validationRules = new TeamValidator();
            ValidationResult result = validationRules.Validate(model.Team);
            if (result.IsValid)
            {
                _teamService.Update(model.Team);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
