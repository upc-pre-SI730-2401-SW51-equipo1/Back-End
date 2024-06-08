using ChromaComics.Comics.Domain.Models;

namespace ChromaComics.Comics.Domain.Repositories;

public interface IRecommendationRepository
{
    Task<IEnumerable<Recommendation>> ListAsync();
    Task AddAsync(Recommendation recommendation);
    Task<Recommendation> FindByIdAsync(int id);
    void Update(Recommendation recommendation);
    void Remove(Recommendation recommendation);
}