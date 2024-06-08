using ChromaComics.Comics.Domain.Models;
using ChromaComics.Comics.Domain.Repositories;
using ChromaComics.Comics.Domain.Services;
using ChromaComics.Comics.Domain.Services.Communication;

namespace ChromaComics.Comics.Services;

public class ComicService : IComicService
{
    private readonly IComicRepository _comicRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ComicService(IComicRepository comicRepository, ICategoryRepository categoryRepository)
    {
        _comicRepository = comicRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Comic>> ListAsync()
    {
        return await _comicRepository.ListAsync();
    }

    public async Task<IEnumerable<Comic>> ListByCategoryIdAsync(int categoryId)
    {
        return await _comicRepository.FindByCategoryIdAsync(categoryId);
    }

    public async Task<ComicResponse> SaveAsync(Comic comic)
    {
        // Validate CategoryId

        var existingCategory = await _categoryRepository.FindByIdAsync(comic.CategoryId);

        if (existingCategory == null)
            return new ComicResponse("Invalid Category");
        
        // Validate Title

        var existingComicWithTitle = await _comicRepository.FindByTitleAsync(comic.Title);

        if (existingComicWithTitle != null)
            return new ComicResponse("Comic title already exists.");

        try
        {
            // Add Comic
            await _comicRepository.AddAsync(comic);
            
            // Return response
            return new ComicResponse(comic);

        }
        catch (Exception e)
        {
            // Error Handling
            return new ComicResponse($"An error occurred while saving the comic: {e.Message}");
        }

        
    }

    public async Task<ComicResponse> UpdateAsync(int comicId, Comic comic)
    {
        var existingComic = await _comicRepository.FindByIdAsync(comicId);
        
        // Validate Comic

        if (existingComic == null)
            return new ComicResponse("Comic not found.");

        // Validate CategoryId

        var existingCategory = await _categoryRepository.FindByIdAsync(comic.CategoryId);

        if (existingCategory == null)
            return new ComicResponse("Invalid Category");
        
        // Validate Title

        var existingComicWithTitle = await _comicRepository.FindByTitleAsync(comic.Title);

        if (existingComicWithTitle != null && existingComicWithTitle.Id != existingComic.Id)
            return new ComicResponse("Comic title already exists.");
        
        // Modify Fields
        existingComic.Title = comic.Title;
        existingComic.Description = comic.Description;

        try
        {
            _comicRepository.Update(existingComic);
            return new ComicResponse(existingComic);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new ComicResponse($"An error occurred while updating the comic: {e.Message}");
        }

    }

    public async Task<ComicResponse> DeleteAsync(int comicId)
    {
        var existingComic = await _comicRepository.FindByIdAsync(comicId);
        
        // Validate Comic

        if (existingComic == null)
            return new ComicResponse("Comic not found.");
        
        try
        {
            _comicRepository.Remove(existingComic);

            return new ComicResponse(existingComic);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new ComicResponse($"An error occurred while deleting the Comic: {e.Message}");
        }

    }
}