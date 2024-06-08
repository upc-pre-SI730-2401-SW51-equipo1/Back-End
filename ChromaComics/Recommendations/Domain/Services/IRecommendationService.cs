using ChromaComics.Comics.Domain.Models;
using ChromaComics.Comics.Domain.Services.Communication;

namespace ChromaComics.Comics.Domain.Services;

public interface IRecommendationService
{
    Task<IEnumerable<Recommendation>> ListAsync();
    Task<RecommendationResponse> SaveAsync(Recommendation recommendation);
    Task<RecommendationResponse> UpdateAsync(int id, Recommendation recommendation);
    Task<RecommendationResponse> DeleteAsync(int id);
}