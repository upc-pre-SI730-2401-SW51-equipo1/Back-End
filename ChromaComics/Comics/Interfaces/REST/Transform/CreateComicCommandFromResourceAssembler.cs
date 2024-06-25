
using ChromaComics.Comics.Domain.Model.Commands;
using ChromaComics.Comics.Interfaces.REST.Resources;

namespace ChromaComics.Comics.Interfaces.REST.Transform;

public static class CreateComicCommandFromResourceAssembler
{
    public static CreateComicCommand ToCommandFromResource(CreateComicResource resource)
    {
        return new CreateComicCommand(resource.Title, resource.Summary, resource.CategoryId);
    }
}