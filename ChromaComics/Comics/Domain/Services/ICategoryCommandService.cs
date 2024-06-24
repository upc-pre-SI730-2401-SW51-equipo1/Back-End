
using ChromaComics.Comics.Domain.Model.Commands;
using ChromaComics.Comics.Domain.Model.Entities;

namespace ChromaComics.Comics.Domain.Services;

public interface ICategoryCommandService
{
    public Task<Category?> Handle(CreateCategoryCommand command);
}