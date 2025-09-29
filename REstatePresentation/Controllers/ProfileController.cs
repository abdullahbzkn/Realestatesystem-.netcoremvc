using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using REstatePresentation.Models;

namespace REstatePresentation.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ProfileController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.UserName = values.UserName;
            userEditViewModel.Mail = values.Email;
            userEditViewModel.Phone = values.PhoneNumber;
            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if(userEditViewModel.Password == userEditViewModel.ConfirmPassword)
            {
                values.UserName = userEditViewModel.UserName;
                values.Email = userEditViewModel.Mail;
                values.PhoneNumber = userEditViewModel.Phone;
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, userEditViewModel.Password);
                var result = await _userManager.UpdateAsync(values);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index","Login");
        }
    }
}
