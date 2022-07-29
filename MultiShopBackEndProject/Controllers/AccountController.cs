using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShopBackEndProject.Models;
using MultiShopBackEndProject.ViewModels;
using System.Threading.Tasks;

namespace MultiShopBackEndProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();
            if (!registerVM.Terms)
            {
                ModelState.AddModelError("Terms", "You have to accept our terms");
            }

            AppUser user = new AppUser
            {
                Firstname = registerVM.firstName,
                Lastname = registerVM.lastName,
                UserName = registerVM.username,
                Email = registerVM.email
            };

            IdentityResult result = await _userManager.CreateAsync(user,registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(loginVM.userName);
            if(user == null) return View();
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, loginVM.password, loginVM.rememberMe, true);
            if (!signInResult.Succeeded)
            {
                if (signInResult.IsLockedOut)
                {
                    ModelState.AddModelError("", "You've been banned for 10 minutes");
                    return View();
                }
                ModelState.AddModelError("", "Your password or username is incorrect");
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
