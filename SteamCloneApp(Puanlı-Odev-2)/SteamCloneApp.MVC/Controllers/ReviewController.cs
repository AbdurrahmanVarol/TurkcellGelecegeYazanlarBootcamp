using Microsoft.AspNetCore.Mvc;

namespace SteamCloneApp.MVC.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
