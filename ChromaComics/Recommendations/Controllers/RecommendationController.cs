using ChromaComics.Recommendations.Domain.Models;
using ChromaComics.Recommendations.Domain.Services;
using ChromaComics.Recommendations.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<RecommendationResource>> GetAllAsync()
        {
            var recommendations = await _recommendationService.ListAsync();
            var resources = new List<RecommendationResource>();
            foreach (var recommendation in recommendations)
            {
                resources.Add(new RecommendationResource
                {
                    Id = recommendation.Id,
                    Title = recommendation.Title,
                    Issue = recommendation.Issue,
                    Year = recommendation.Year,
                    Publisher = recommendation.Publisher,
                    Writer = recommendation.Writer,
                    CategoryId = recommendation.CategoryId,
                    Image = recommendation.Image
                });
            }
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveRecommendationResource resource)
        {
            var result = await _recommendationService.SaveAsync(resource);

            if (!result.Success)
                return BadRequest(result.Message);

            var recommendationResource = new RecommendationResource
            {
                Id = result.Resource.Id,
                Title = result.Resource.Title,
                Issue = result.Resource.Issue,
                Year = result.Resource.Year,
                Publisher = result.Resource.Publisher,
                Writer = result.Resource.Writer,
                CategoryId = result.Resource.CategoryId,
                Image = result.Resource.Image
            };
            return Ok(recommendationResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _recommendationService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var recommendationResource = new RecommendationResource
            {
                Id = result.Resource.Id,
                Title = result.Resource.Title,
                Issue = result.Resource.Issue,
                Year = result.Resource.Year,
                Publisher = result.Resource.Publisher,
                Writer = result.Resource.Writer,
                CategoryId = result.Resource.CategoryId,
                Image = result.Resource.Image
            };
            return Ok(recommendationResource);
        }
    }
}