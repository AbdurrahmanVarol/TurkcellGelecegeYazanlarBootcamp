using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SteamCloneApp.Business.Services;
using SteamCloneApp.Business.Dtos.Requests;

namespace SteamCloneApp.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginRequest loginRequest)
        {
            try
            {
                 _authService.LoginAsync(loginRequest).GetAwaiter().GetResult();

                //var claims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                //    new Claim("Name",user.FirstName),
                //    new Claim("FullName",user.FullName)
                //};

                //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //var authenticationProperties = new AuthenticationProperties
                //{
                //    AllowRefresh = true,
                //    IsPersistent = loginRequest.IsKeepLoggedIn,

                //};

                //HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity), authenticationProperties).GetAwaiter().GetResult();
                return RedirectToAction("index", "home");
            }
            catch (Exception exception)
            {
                TempData["LoginException"] = exception.Message;
                return View();
            }


        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync().GetAwaiter().GetResult();
            return RedirectToAction("login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            await _authService.RegisterAsync(registerRequest);
            return Json(new
            {
                isSuccess = true,
            });
        }
    }
}
