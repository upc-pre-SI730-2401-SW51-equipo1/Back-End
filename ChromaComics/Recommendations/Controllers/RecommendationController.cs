using AutoMapper;
using ChromaComics.Recommendations.Domain.Models;
using ChromaComics.Recommendations.Domain.Services;
using ChromaComics.Recommendations.Resources;
using ChromaComics.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ChromaComics.Recommendations.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class RecommendationsController : ControllerBase
{
    private readonly IRecommendationService _recommendationService;
    private readonly IMapper _mapper;

    public RecommendationsController(IRecommendationService recommendationService, IMapper mapper)
    {
        _recommendationService = recommendationService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<RecommendationResource>> GetAllAsync()
    {
        var recommendations = await _recommendationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Recommendation>, IEnumerable<RecommendationResource>>(recommendations);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveRecommendationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var recommendation = _mapper.Map<SaveRecommendationResource, Recommendation>(resource);

        var result = await _recommendationService.SaveAsync(recommendation);

        if (!result.Success)
            return BadRequest(result.Message);

        var recommendationResource = _mapper.Map<Recommendation, RecommendationResource>(result.Resource);

        return Ok(recommendationResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRecommendationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var recommendation = _mapper.Map<SaveRecommendationResource, Recommendation>(resource);
        var result = await _recommendationService.UpdateAsync(id, recommendation);

        if (!result.Success)
            return BadRequest(result.Message);

        var recommendationResource = _mapper.Map<Recommendation, RecommendationResource>(result.Resource);

        return Ok(recommendationResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _recommendationService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var recommendationResource = _mapper.Map<Recommendation, RecommendationResource>(result.Resource);

        return Ok(recommendationResource);
    }
}