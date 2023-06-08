using Microsoft.AspNetCore.Mvc;
using SteamCloneApp.Business.Dtos.Responses;
using SteamCloneApp.Business.Services;
using SteamCloneApp.MVC.Models;
using System.Text.Json;

namespace SteamCloneApp.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IGameService _gameService;

        public CartController(IGameService gameService)
        {
            _gameService = gameService;
        }

        private List<CartModel> GetGamesFromSession()
        {
            var gamesInSession = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrWhiteSpace(gamesInSession))
            {
                return new List<CartModel>();
            }
            return JsonSerializer.Deserialize<List<CartModel>>(gamesInSession);
        }
        private void SetSession(List<CartModel> cartModels)
        {
            var serializedGames = JsonSerializer.Serialize(cartModels);
            HttpContext.Session.SetString("Cart", serializedGames);
        }
        [HttpGet]
        public IActionResult GetGamesInCart()
        {
            var games = GetGamesFromSession();

            var result = games.Select(async p => await _gameService.GetGameByIdForCartAsync(p.GameId)).ToList();

            return Json(result);

        }
        [HttpPost]
        public IActionResult AddToCart([FromBody] CartModel cartModel)
        {
            var games = GetGamesFromSession();

            if (!games.Any(p => p.GameId == cartModel.GameId))
            {
                games.Add(cartModel);
                SetSession(games);
            }
            return Json(new
            {
                Count = games.Count
            });
        }

        [HttpPost]
        public IActionResult RemoveFromCart([FromBody] CartModel cartModel)
        {
            var games = GetGamesFromSession();
            var deletedGame = games.FirstOrDefault(p=>p.GameId == cartModel.GameId);
            games.Remove(deletedGame);

            SetSession(games);

            var result = games.Select(p => _gameService.GetGameByIdForCartAsync(p.GameId).GetAwaiter().GetResult()).ToList();
            return Json(result);
        }

        [HttpPost]
        public void ClearCart()
        {
            SetSession(new List<CartModel>());
        }
        [HttpGet]
        public IActionResult CartDetail()
        {
            var gamesInCart = GetGamesFromSession();
            var games = gamesInCart.Select(p => _gameService.GetGameByIdForCartAsync(p.GameId).GetAwaiter().GetResult());
            var viewModel = new CartDetailViewModel
            {
                Games = games,
                IsAuthenticated = HttpContext.User.Identity.IsAuthenticated
            };
            return View(viewModel);            
        }
    }
}
