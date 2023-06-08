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
        public IActionResult Login(string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest, string? returnUrl)
        {
            try
            {
                var user = await _authService.LoginAsync(loginRequest);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.FirstName),
                    new Claim("FullName",user.FullName)
                };
                claims.AddRange(user.Roles.Select(p => new Claim(ClaimTypes.Role, p)));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = loginRequest.IsKeepLoggedIn,
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity), authenticationProperties);
                if (string.IsNullOrWhiteSpace(returnUrl))
                {
                    return RedirectToAction("index", "home");
                }
                return Redirect(returnUrl);
            }
            catch (Exception exception)
            {
                TempData["LoginException"] = exception.Message;
                return View();
            }


        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
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
            TempData["RegisterMessage"] = "Kullanıcı eklendi.";
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
