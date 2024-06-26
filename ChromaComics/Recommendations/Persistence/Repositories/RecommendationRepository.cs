using ChromaComics.Recommendations.Domain.Models;
using ChromaComics.Recommendations.Domain.Repositories;
using ChromaComics.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChromaComics.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace ChromaComics.Recommendations.Persistence.Repositories
{
    public class RecommendationRepository : BaseRepository<Recommendation>, IRecommendationRepository
    {
        private readonly AppDbContext _context;

        public RecommendationRepository(AppDbContext context) : base(context)
        {
            _context = context;
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
}