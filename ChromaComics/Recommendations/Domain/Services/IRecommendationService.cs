using ChromaComics.Recommendations.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChromaComics.Recommendations.Models;
using ChromaComics.Recommendations.Resources;

public interface IRecommendationService
{
    Task<IEnumerable<Recommendation>> ListAsync();
    Task<RecommendationResponse> SaveAsync(SaveRecommendationResource resource);
    Task<RecommendationResponse> UpdateAsync(int id, SaveRecommendationResource resource);
    Task<RecommendationResponse> DeleteAsync(int id);
    Task SaveChangesAsync();
}