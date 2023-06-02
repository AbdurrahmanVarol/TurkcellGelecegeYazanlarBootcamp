using SteamCloneApp.Business.Dtos.Responses;
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
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;

        public GenreService(IGenreRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GenreResponse>> GetAllAsync()
        {
            var genres = await _repository.GetAllAsync();

            var serialized = JsonSerializer.Serialize(genres);
            return JsonSerializer.Deserialize<IEnumerable<GenreResponse>>(serialized);
        }
    }
}
