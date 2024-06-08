using ChromaComics.Comics.Domain.Models;
using ChromaComics.Comics.Domain.Repositories;
using ChromaComics.Comics.Domain.Services;
using ChromaComics.Comics.Domain.Services.Communication;

namespace ChromaComics.Comics.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> ListAsync()
    {
        return await _categoryRepository.ListAsync();
    }

    public async Task<CategoryResponse> SaveAsync(Category category)
    {
        try
        {
            await _categoryRepository.AddAsync(category);
            return new CategoryResponse(category);
        }
        catch (Exception e)
        {
            return new CategoryResponse($"An error occurred while saving the category: {e.Message}");
        }
    }

    public async Task<CategoryResponse> UpdateAsync(int id, Category category)
    {
        var existingCategory = await _categoryRepository.FindByIdAsync(id);

        if (existingCategory == null)
            return new CategoryResponse("Category not found.");

        existingCategory.Name = category.Name;

        try
        {
            _categoryRepository.Update(existingCategory);
            return new CategoryResponse(existingCategory);
        }
        catch (Exception e)
        {
            return new CategoryResponse($"An error occurred while updating the category: {e.Message}");
        }
    }

    public async Task<CategoryResponse> DeleteAsync(int id)
    {
        var existingCategory = await _categoryRepository.FindByIdAsync(id);

        if (existingCategory == null)
            return new CategoryResponse("Category not found.");

        try
        {
            _categoryRepository.Remove(existingCategory);

            return new CategoryResponse(existingCategory);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new CategoryResponse($"An error occurred while deleting the category: {e.Message}");
        }
    }
}