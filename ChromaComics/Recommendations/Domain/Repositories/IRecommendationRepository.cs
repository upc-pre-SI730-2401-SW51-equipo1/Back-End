using ChromaComics.Recommendations.Domain.Models;

namespace ChromaComics.Recommendations.Domain.Repositories;

public interface IRecommendationRepository
{
    Task<IEnumerable<Recommendation>> ListAsync();
    Task AddAsync(Recommendation recommendation);
    Task<Recommendation> FindByIdAsync(int id);
    void Update(Recommendation recommendation);
    void Remove(Recommendation recommendation);
}