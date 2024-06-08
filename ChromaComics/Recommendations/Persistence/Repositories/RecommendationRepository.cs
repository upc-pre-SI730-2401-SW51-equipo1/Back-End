using ChromaComics.Comics.Domain.Models;
using ChromaComics.Comics.Domain.Repositories;
using ChromaComics.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChromaComics.Shared.Persistence.Repositories;

public class RecommendationRepository : BaseRepository, IRecommendationRepository
{
    public RecommendationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Recommendation>> ListAsync()
    {
        return await _context.Recommendations.ToListAsync();
    }

    public async Task AddAsync(Recommendation recommendation)
    {
        await _context.Recommendations.AddAsync(recommendation);
    }

    public async Task<Recommendation> FindByIdAsync(int id)
    {
        return await _context.Recommendations.FindAsync(id);
    }

    public void Update(Recommendation recommendation)
    {
        _context.Recommendations.Update(recommendation);
    }

    public void Remove(Recommendation recommendation)
    {
        _context.Recommendations.Remove(recommendation);
    }
}