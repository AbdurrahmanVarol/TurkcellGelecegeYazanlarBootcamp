using Microsoft.AspNetCore.Mvc;

namespace SteamCloneApp.MVC.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
