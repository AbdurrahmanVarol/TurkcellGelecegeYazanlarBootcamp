using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SteamCloneApp.Business.Dtos.Requests;
using SteamCloneApp.Business.Services;
using SteamCloneApp.MVC.Models;
using System.Security.Claims;

namespace SteamCloneApp.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IPublisherService _publisherService;
        private readonly IGenreService _genreService;
        private readonly IDeveloperService _developerService;
        private readonly IUserService _userService;
        private readonly IImageService _imageService;
        private Guid UserId => Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
        public GameController(IGameService gameService, IPublisherService publisherService, IGenreService genreService, IDeveloperService developerService, IUserService userService, IImageService imageService)
        {
            _gameService = gameService;
            _publisherService = publisherService;
            _genreService = genreService;
            _developerService = developerService;
            _userService = userService;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateGame()
        {
            var publishers = await _publisherService.GetAllAsync();
            var genres = await _genreService.GetAllAsync();
            var developers = await _developerService.GetAllAsync();

            var viewModel = new CreateGameViewModel
            {
                Publishers = publishers,
                Genres = genres,
                Developers = developers
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateGame(CreateGameRequest createGameRequest)
        {
            await _gameService.AddAsync(createGameRequest);
            return Ok(createGameRequest);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GameDetail(Guid id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            return View(game);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Library()
        {
            var games = await _gameService.GetGamesByUserIdAsync(UserId);
            return View(games);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PurchaseGame([FromBody] PurchaseGameRequest purchaseGameRequest)
        {
            purchaseGameRequest.UserId = UserId;
            await _userService.AddGameToUser(purchaseGameRequest);
            HttpContext.Session.SetString("Cart", "");
            return Json(true);
        }

        [HttpGet]
        public async Task<IActionResult> GameSettings()
        {
            var games = await _gameService.GetAllAsync();
            return View(games);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            await _gameService.DeleteAsync(id);
                 var games = await _gameService.GetAllAsync();
            TempData["GameSettingInfo"] = "Oyun Silindi";
            return View(nameof(GameSettings), games);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateGame(Guid id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            if (game is null)
            {
                TempData["GameSettingInfo"] = "Oyun Bulunamadı";
                return View(nameof(GameSettings));
            }
            var publishers = await _publisherService.GetAllAsync();
            var genres = await _genreService.GetAllAsync();
            var developers = await _developerService.GetAllAsync();
            var images = await _imageService.GetImageUrlsBtGameIdAsync(id);

            ViewBag.Publishers = publishers.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            ViewBag.Developers = developers.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            ViewBag.Genres = genres;
            ViewBag.ImageUrls = images;

            return View(game);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGame(UpdateGameRequest updateGameRequest)
        {
            await _gameService.UpdateAsync(updateGameRequest);
            TempData["GameSettingInfo"] = "Oyun Güncellendi";
            return Ok(true);
        }

    }
}
