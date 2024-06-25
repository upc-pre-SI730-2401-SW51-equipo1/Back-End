
using ChromaComics.Comics.Domain.Model.Aggregates;
using ChromaComics.Comics.Interfaces.REST.Resources;
using Microsoft.OpenApi.Extensions;

namespace ChromaComics.Comics.Interfaces.REST.Transform;

public static class ComicResourceFromEntityAssembler
{
    public static ComicResource ToResourceFromEntity(Comic comic)
    {
        return new ComicResource(
            comic.Id,
            comic.Title,
            comic.Summary,
            CategoryResourceFromEntityAssembler.ToResourceFromEntity(comic.Category),
            comic.Status.GetDisplayName());
    }
}