using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SteamCloneApp.MVC.Controllers
{
    public class BaseController : Controller
    {
        protected Guid? GetUserId()
        {
            if(Guid.TryParse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value,out var userId))
            {
                return userId;
            }
            return null;
        }
    }
}
