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
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task AddAsync(CreateReviewRequest createReviewRequest)
        {
            var serialized = JsonSerializer.Serialize(createReviewRequest);
            var review = JsonSerializer.Deserialize<Review>(serialized);
            await _reviewRepository.AddAsync(review);
        }
    }
}
