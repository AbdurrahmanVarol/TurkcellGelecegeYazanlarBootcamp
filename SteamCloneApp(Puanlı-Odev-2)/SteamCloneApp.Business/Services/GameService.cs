using SteamCloneApp.Business.Dtos.Requests;
using SteamCloneApp.DataAccess.Repositories;
using SteamCloneApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGenreRepository _genreRepository;
        public GameService(IGameRepository gameRepository, IGenreRepository genreRepository)
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
        }

        public async Task AddAsync(CreateGameRequest request)
        {
            
            var game = new Game
            {
                Description = request.Description,
                DevelopedById = request.DevelopedById,
                PublishedById = request.PublishedById,
                Title = request.Title,
                Price = request.Price,
                Genres = request.Genres.Select(p => _genreRepository.GetAsync(g=>g.Id == p).GetAwaiter().GetResult()).ToList()
            };
            await _gameRepository.AddAsync(game);
        }
    }
}
