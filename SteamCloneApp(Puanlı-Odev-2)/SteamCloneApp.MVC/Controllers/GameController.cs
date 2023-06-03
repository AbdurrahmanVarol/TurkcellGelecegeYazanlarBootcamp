using Microsoft.AspNetCore.Mvc;
using SteamCloneApp.Business.Dtos.Requests;
using SteamCloneApp.Business.Services;
using SteamCloneApp.MVC.Models;

namespace SteamCloneApp.MVC.Controllers
{
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
        public IActionResult CreateGame()
        {
            var publishers = _publisherService.GetAllAsync().GetAwaiter().GetResult();
            var genres = _genreService.GetAllAsync().GetAwaiter().GetResult();
            var developers = _developerService.GetAllAsync().GetAwaiter().GetResult();
            var viewModel = new CreateGameViewModel
            {
                Publishers = publishers,
                Genres = genres,
                Developers = developers
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult CreateGame(CreateGameRequest createGameRequest)
        {
            _gameService.AddAsync(createGameRequest).GetAwaiter().GetResult();
            return Ok(createGameRequest);
        }

        [HttpGet]
        public IActionResult GameDetail(Guid id)
        {
           var game = _gameService.GetGameByIdAsync(id).GetAwaiter().GetResult();
            return View(game);
        }
    }
}
