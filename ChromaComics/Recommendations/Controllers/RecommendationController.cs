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
                    BookTitle = recommendation.BookTitle,
                    Description = recommendation.Description,
                    Genre = recommendation.Genre,
                    Author = recommendation.Author
                });
            }
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveRecommendationResource resource)
        {
            var result = await _recommendationService.SaveAsync(resource);

            if (!result.Success || result.Resource == null)
                return BadRequest(result.Message);

            var recommendationResource = new RecommendationResource
            {
                Id = result.Resource.Id,
                BookTitle = result.Resource.BookTitle ?? string.Empty,
                Description = result.Resource.Description ?? string.Empty,
                Genre = result.Resource.Genre ?? string.Empty,
                Author = result.Resource.Author ?? string.Empty
            };
            return Ok(recommendationResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRecommendationResource resource)
        {
            var result = await _recommendationService.UpdateAsync(id, resource);

            if (!result.Success || result.Resource == null)
                return BadRequest(result.Message);

            var recommendationResource = new RecommendationResource
            {
                Id = result.Resource.Id,
                BookTitle = result.Resource.BookTitle ?? string.Empty,
                Description = result.Resource.Description ?? string.Empty,
                Genre = result.Resource.Genre ?? string.Empty,
                Author = result.Resource.Author ?? string.Empty
            };
            return Ok(recommendationResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _recommendationService.DeleteAsync(id);

            if (!result.Success || result.Resource == null)
                return BadRequest(result.Message);

            var recommendationResource = new RecommendationResource
            {
                Id = result.Resource.Id,
                BookTitle = result.Resource.BookTitle ?? string.Empty,
                Description = result.Resource.Description ?? string.Empty,
                Genre = result.Resource.Genre ?? string.Empty,
                Author = result.Resource.Author ?? string.Empty
            };
            return Ok(recommendationResource);
        }
    }
}