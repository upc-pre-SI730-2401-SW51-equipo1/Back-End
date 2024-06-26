using ChromaComics.Recommendations.Domain.Services;
using ChromaComics.Recommendations.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChromaComics.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace ChromaComics.Recommendations.Controllers
{
    [Route("/api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<RecommendationResource>> GetAllAsync()
        {
            var recommendations = await _recommendationService.ListAsync();
            var resources = new List<RecommendationResource>();
            foreach (var recommendation in recommendations)
            {
                resources.Add(new RecommendationResource
                {
                    Id = recommendation.Id,
                    BookTitle = recommendation.BookTitle,
                    Description = recommendation.Description,
                    Genre = recommendation.Genre,
                    Author = recommendation.Author
                });
            }
            return resources;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] SaveRecommendationResource resource)
        {
            var result = await _recommendationService.SaveAsync(resource);

            if (!result.Success)
                return BadRequest(result.Message);

            var recommendationResource = new RecommendationResource
            {
                Id = result.Resource.Id,
                BookTitle = result.Resource.BookTitle,
                Description = result.Resource.Description,
                Genre = result.Resource.Genre,
                Author = result.Resource.Author
            };
            return Ok(recommendationResource);
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _recommendationService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var recommendationResource = new RecommendationResource
            {
                Id = result.Resource.Id,
                BookTitle = result.Resource.BookTitle,
                Description = result.Resource.Description,
                Genre = result.Resource.Genre,
                Author = result.Resource.Author
            };
            return Ok(recommendationResource);
        }
    }
}