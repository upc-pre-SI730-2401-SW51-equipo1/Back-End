
using ChromaComics.Comics.Domain.Model.Aggregates;
using ChromaComics.Shared.Domain.Repositories;

namespace ChromaComics.Comics.Domain.Repositories;

public interface IComicRepository : IBaseRepository<Comic>
{
    Task<IEnumerable<Comic>> FindByCategoryIdAsync(int categoryId);
}