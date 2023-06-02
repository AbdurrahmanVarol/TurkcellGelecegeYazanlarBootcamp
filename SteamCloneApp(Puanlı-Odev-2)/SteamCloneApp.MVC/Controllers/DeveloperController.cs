using Microsoft.AspNetCore.Mvc;

namespace SteamCloneApp.MVC.Controllers
{
    public class DeveloperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
