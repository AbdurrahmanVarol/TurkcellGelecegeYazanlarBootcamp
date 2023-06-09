using AutoMapper;
using SteamCloneApp.Business.Dtos.Responses;
using SteamCloneApp.DataAccess.Repositories;

namespace SteamCloneApp.Business.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;

        public DeveloperService(IDeveloperRepository developerRepository, IMapper mapper)
        {
            _developerRepository = developerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DeveloperResponse>> GetAllAsync()
        {
            var developers = await _developerRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<DeveloperResponse>>(developers);
        }
    }
}
