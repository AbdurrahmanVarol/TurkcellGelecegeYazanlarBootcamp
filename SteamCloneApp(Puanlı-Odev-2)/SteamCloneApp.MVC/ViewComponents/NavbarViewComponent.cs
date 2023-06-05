
using Microsoft.AspNetCore.Mvc;
using SteamCloneApp.MVC.Models;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace SteamCloneApp.MVC.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
           var roles =  HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(p=>p.Value).ToList();
            var isAuthenticated = HttpContext.User.Identity.IsAuthenticated;

            var serialized = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrWhiteSpace(serialized))
            {
                return View(new NavbarViewModel
                {
                    CartItemCount = 0,
                    IsAuthenticated = isAuthenticated,
                    Roles = roles
                });
            }
            var cartItems = JsonSerializer.Deserialize<List<CartModel>>(serialized);

            return View(new NavbarViewModel
            {
                CartItemCount = cartItems.Count,
                IsAuthenticated = isAuthenticated,
                Roles = roles
            });
        }
    }
}
