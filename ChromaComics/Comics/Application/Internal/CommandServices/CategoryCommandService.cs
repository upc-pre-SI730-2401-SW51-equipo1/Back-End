using ChromaComics.Comics.Domain.Model.Commands;
using ChromaComics.Comics.Domain.Model.Entities;
using ChromaComics.Comics.Domain.Repositories;
using ChromaComics.Comics.Domain.Services;
using ChromaComics.Shared.Domain.Repositories;

namespace ChromaComics.Comics.Application.Internal.CommandServices;

public class CategoryCommandService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : ICategoryCommandService
{
    /**
     * Create Category Command Handler
     * <summary>
     *     This method is responsible for handling the command and executing the business logic for creating a category.
     *     It is also responsible for calling the repository to persist the data.
     * </summary>
     * <param name="command">The command containing the name for the category</param>
     * <returns>The category entity.</returns>
     */
    public async Task<Category?> Handle(CreateCategoryCommand command)
    {
        var category = new Category(command.Name);
        await categoryRepository.AddAsync(category);
        await unitOfWork.CompleteAsync();
        return category;
    }
}