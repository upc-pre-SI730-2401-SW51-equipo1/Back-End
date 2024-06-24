
using ChromaComics.Comics.Domain.Model.Aggregates;
using ChromaComics.Comics.Domain.Repositories;
using ChromaComics.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChromaComics.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChromaComics.Comics.Infrastructure.Persistence.EFC.Repositories;

public class ComicRepository(AppDbContext context) : BaseRepository<Comic>(context), IComicRepository
{
    /**
     * Find Comic By id
     * <summary>
     *     This method is used to find a comic by id, overriding the base method to include the category
     * </summary>
     * @param int id
     */
    public new async Task<Comic?> FindByIdAsync(int id) =>
        await Context.Set<Comic>().Include(t => t.Category)
            .Where(t => t.Id == id).FirstOrDefaultAsync();
    
    public new async Task<IEnumerable<Comic>> ListAsync()
    {
        return await Context.Set<Comic>()
            .Include(comic => comic.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Comic>> FindByCategoryIdAsync(int categoryId)
    {
        return await Context.Set<Comic>()
            .Include(comic => comic.Category)
            .Where(comic => comic.CategoryId == categoryId)
            .ToListAsync();
    }
}