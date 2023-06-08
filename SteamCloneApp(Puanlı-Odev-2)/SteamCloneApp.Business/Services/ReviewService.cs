using AutoMapper;
using SteamCloneApp.Business.Dtos.Requests;
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
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateReviewRequest createReviewRequest)
        {
            var review = _mapper.Map<Review>(createReviewRequest);
            await _reviewRepository.AddAsync(review);
        }

        public async Task<IEnumerable<ReviewResponse>> GetReviewsByGameId(Guid gameId)
        {
            var reviews = (await _reviewRepository.GetAllAsync(p => p.GameId == gameId)).OrderByDescending(p => p.PostedAt);
            return _mapper.Map<IEnumerable<ReviewResponse>>(reviews);
        }
    }
}
