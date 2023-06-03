using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SteamCloneApp.Business.Dtos.Requests;
using SteamCloneApp.Business.Services;
using SteamCloneApp.MVC.Models;

namespace SteamCloneApp.MVC.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IPublisherService _publisherService;
        private readonly IGenreService _genreService;
        private readonly IDeveloperService _developerService;

        public GameController(IGameService gameService, IPublisherService publisherService, IGenreService genreService, IDeveloperService developerService)
        {
            _gameService = gameService;
            _publisherService = publisherService;
            _genreService = genreService;
            _developerService = developerService;
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
    }
}
