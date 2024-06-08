using ChromaComics.Comics.Domain.Models;

namespace ChromaComics.Comics.Domain.Repositories;

public interface IComicRepository
{
    Task<IEnumerable<Comic>> ListAsync();
    Task AddAsync(Comic tutorial);
    Task<Comic> FindByIdAsync(int tutorialId);
    Task<Comic> FindByTitleAsync(string title);
    Task<IEnumerable<Comic>> FindByCategoryIdAsync(int categoryId);
    void Update(Comic tutorial);
    void Remove(Comic tutorial);
}