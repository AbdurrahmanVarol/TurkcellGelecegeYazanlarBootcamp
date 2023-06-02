using Microsoft.AspNetCore.Mvc;

namespace SteamCloneApp.MVC.Controllers
{
    public class PublisherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
