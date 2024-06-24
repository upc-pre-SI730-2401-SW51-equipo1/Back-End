
using ChromaComics.Comics.Domain.Model.Commands;
using ChromaComics.Comics.Interfaces.REST.Resources;

namespace ChromaComics.Comics.Interfaces.REST.Transform;

public static class CreateCategoryCommandFromResourceAssembler
{
    public static CreateCategoryCommand ToCommandFromResource(CreateCategoryResource resource)
    {
        return new CreateCategoryCommand(resource.Name);
    }
}