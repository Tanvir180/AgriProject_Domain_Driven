using AgriTourismArchi.DTO;
using AgriTourismArchi.Handler.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AgriTourismArchi.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHandler _userService;

        public AccountController(IUserHandler userService)
        {
            _userService = userService;
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationDTO dto)
        {
            if (ModelState.IsValid)
            {
                await _userService.RegisterUserAsync(dto);
                return RedirectToAction("Login");
            }
            return View(dto);
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.AuthenticateUserAsync(dto);
                if (user != null)
                {
                    // Implement authentication logic (e.g., sign in the user)
                    // Example: HttpContext.Session.SetString("UserEmail", user.Email);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(dto);
        }
    }
}
