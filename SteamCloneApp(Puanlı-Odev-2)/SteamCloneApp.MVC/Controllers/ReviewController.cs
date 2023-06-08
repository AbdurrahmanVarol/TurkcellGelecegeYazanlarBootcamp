using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SteamCloneApp.Business.Dtos.Requests;
using SteamCloneApp.Business.Services;
using System.Security.Claims;

namespace SteamCloneApp.MVC.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private Guid UserId => Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReviewsByGameId(Guid id)
        {
            var reviews = await _reviewService.GetReviewsByGameId(id);
            return Ok(reviews);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewRequest createReviewRequest)
        {
            createReviewRequest.UserId = UserId;
            createReviewRequest.PostedAt = DateTime.Now;
            await _reviewService.AddAsync(createReviewRequest);
            return Ok(true);
        }
    }
}
