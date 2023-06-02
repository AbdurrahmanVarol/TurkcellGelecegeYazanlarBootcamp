using SteamCloneApp.Business.Dtos.Responses;
using SteamCloneApp.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperService(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public async Task<IEnumerable<DeveloperResponse>> GetAllAsync()
        {
            var developers = await _developerRepository.GetAllAsync();

            var serialized = JsonSerializer.Serialize(developers);
            return JsonSerializer.Deserialize<IEnumerable<DeveloperResponse>>(serialized);
        }
    }
}
