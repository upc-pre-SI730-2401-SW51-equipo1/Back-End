using ChromaComics.Recommendations.Domain.Models;
using ChromaComics.Recommendations.Domain.Services.Communication;

namespace ChromaComics.Recommendations.Domain.Services;

public interface IRecommendationService
{
    Task<IEnumerable<Recommendation>> ListAsync();
    Task<RecommendationResponse> SaveAsync(Recommendation recommendation);
    Task<RecommendationResponse> UpdateAsync(int id, Recommendation recommendation);
    Task<RecommendationResponse> DeleteAsync(int id);
}