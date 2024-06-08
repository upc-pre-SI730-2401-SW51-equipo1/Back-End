using ChromaComics.Comics.Domain.Models;
using ChromaComics.Comics.Domain.Services.Communication;

namespace ChromaComics.Comics.Domain.Services;

public interface IComicService
{
    Task<IEnumerable<Comic>> ListAsync();
    Task<IEnumerable<Comic>> ListByCategoryIdAsync(int categoryId);
    Task<ComicResponse> SaveAsync(Comic comic);
    Task<ComicResponse> UpdateAsync(int comicId, Comic comic);
    Task<ComicResponse> DeleteAsync(int comicId);
}