using SteamCloneApp.Business.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Services
{
    public interface IReviewService
    {
        Task AddAsync(CreateReviewRequest createReviewRequest);
    }
}
