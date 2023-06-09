using AutoMapper;
using SteamCloneApp.Business.Dtos.Responses;
using SteamCloneApp.DataAccess.Repositories;
using SteamCloneApp.Entities.Entities;

namespace SteamCloneApp.Business.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository repository, IMapper mapper)
        {
            _genreRepository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreResponse>> GetAllAsync()
        {
            var genres = await _genreRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GenreResponse>>(genres);
        }

        public async Task<IEnumerable<Genre>> GetGenresByIdAsync(List<int> ids) => await _genreRepository.GetAllAsync(x => ids.Contains(x.Id));
    }
}
