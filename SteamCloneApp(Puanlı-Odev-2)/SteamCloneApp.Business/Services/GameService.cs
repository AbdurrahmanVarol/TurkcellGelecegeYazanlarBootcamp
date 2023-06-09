using AutoMapper;
using SteamCloneApp.Business.Dtos.Requests;
using SteamCloneApp.Business.Dtos.Responses;
using SteamCloneApp.DataAccess.Repositories;
using SteamCloneApp.Entities.Entities;

namespace SteamCloneApp.Business.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGenreService _genreService;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        public GameService(IGameRepository gameRepository, IMapper mapper, IImageService imageService, IGenreService genreService)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            _imageService = imageService;
            _genreService = genreService;
        }

        public async Task AddAsync(CreateGameRequest request)
        {
            var genres = (await _genreService.GetGenresByIdAsync(request.Genres)).ToList();

            var game = new Game
            {
                Description = request.Description,
                DevelopedById = request.DevelopedById,
                PublishedById = request.PublishedById,
                ReleaseAt = request.ReleaseAt,
                CoverUrl = request.CoverUrl,
                IconUrl = request.IconUrl,
                Title = request.Title,
                Price = request.Price,
                Genres = genres
            };
            await _gameRepository.AddAsync(game);

            await _imageService.AddRange(request.ImageUrls, game.Id);
        }

        public async Task DeleteAsync(Guid id)
        {
            var game = await _gameRepository.GetAsync(p => p.Id == id);

            if (game is null)
            {
                throw new ArgumentNullException(nameof(game));
            }
            await _gameRepository.DeleteAsync(game);
        }

        public async Task UpdateAsync(UpdateGameRequest updateGameRequest)
        {
            var game = await _gameRepository.GetAsync(p => p.Id == updateGameRequest.Id);

            if (game is null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            var genres = (await _genreService.GetGenresByIdAsync(updateGameRequest.Genres)).ToList();

            var addedImages = updateGameRequest.ImageUrls.Where(p => !game.Images.Any(i => i.ImageUrl.Equals(p)));
            var removedImages = game.Images.Where(p => !updateGameRequest.ImageUrls.Any(i => i.Equals(p.ImageUrl)));

            game.Title = updateGameRequest.Title;
            game.Description = updateGameRequest.Description;
            game.Price = updateGameRequest.Price;
            game.CoverUrl = updateGameRequest.CoverUrl;
            game.DevelopedById = updateGameRequest.DevelopedById;
            game.PublishedById = updateGameRequest.PublishedById;
            game.Genres = genres;

            await _gameRepository.UpdateAsync(game);

            await _imageService.AddRange(updateGameRequest.ImageUrls, game.Id);
            await _imageService.RemoveRange(removedImages);

        }

        public async Task<IEnumerable<GameDisplayResponse>> GetAllAsync()
        {
            var games = await _gameRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GameDisplayResponse>>(games).OrderByDescending(p => p.ReleaseAt);
        }
        public async Task<IEnumerable<GameDisplayResponse>> GetGamesByUserIdAsync(Guid userId)
        {

            var games = await _gameRepository.GetAllAsync(g => g.Users.Any(u => u.Id == userId));

            return _mapper.Map<IEnumerable<GameDisplayResponse>>(games);
        }
        public async Task<GameDisplayResponse> GetGameByIdAsync(Guid id)
        {
            var game = await _gameRepository.GetAsync(p => p.Id == id);
            if (game is null)
            {
                throw new ArgumentNullException("---------");
            }
            return _mapper.Map<GameDisplayResponse>(game);
        }

        public async Task<GameCartResponse> GetGameByIdForCartAsync(Guid id)
        {
            var game = await _gameRepository.GetAsync(p => p.Id == id);
            if (game is null)
            {
                throw new ArgumentNullException("---------");
            }
            return _mapper.Map<GameCartResponse>(game);
        }
    }
}
