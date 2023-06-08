using SteamCloneApp.Business.Dtos.Requests;
using SteamCloneApp.Business.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewResponse>> GetReviewsByGameId(Guid gameId);
        Task AddAsync(CreateReviewRequest createReviewRequest);
    }
}
