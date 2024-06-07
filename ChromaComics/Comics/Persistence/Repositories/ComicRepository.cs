using ChromaComics.Comics.Domain.Models;
using ChromaComics.Comics.Domain.Repositories;
using ChromaComics.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChromaComics.Shared.Persistence.Repositories;

public class ComicRepository : BaseRepository, IComicRepository
{
    public ComicRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Comic>> ListAsync()
    {
        return await _context.Comics
            .Include(p => p.Category)
            .ToListAsync();
    }

    public async Task AddAsync(Comic comic)
    {
        await _context.Comics.AddAsync(comic);
    }

    public async Task<Comic> FindByIdAsync(int comicId)
    {
        return await _context.Comics
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == comicId);
        
    }

    public async Task<Comic> FindByTitleAsync(string title)
    {
        return await _context.Comics
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Title == title);
    }

    public async Task<IEnumerable<Comic>> FindByCategoryIdAsync(int categoryId)
    {
        return await _context.Comics
            .Where(p => p.CategoryId == categoryId)
            .Include(p => p.Category)
            .ToListAsync();
    }

    public void Update(Comic comic)
    {
        _context.Comics.Update(comic);
    }

    public void Remove(Comic comic)
    {
        _context.Comics.Remove(comic);
    }
}