using ChromaComics.Comics.Domain.Models;
using ChromaComics.Comics.Domain.Services.Communication;

namespace ChromaComics.Comics.Domain.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> ListAsync();
    Task<CategoryResponse> SaveAsync(Category category);
    Task<CategoryResponse> UpdateAsync(int id, Category category);
    Task<CategoryResponse> DeleteAsync(int id);
}