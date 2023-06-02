using Microsoft.AspNetCore.Mvc;

namespace SteamCloneApp.MVC.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
