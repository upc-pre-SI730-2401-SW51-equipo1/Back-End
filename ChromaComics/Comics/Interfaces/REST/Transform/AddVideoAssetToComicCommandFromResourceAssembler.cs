
using ChromaComics.Comics.Domain.Model.Commands;
using ChromaComics.Comics.Interfaces.REST.Resources;

namespace ChromaComics.Comics.Interfaces.REST.Transform;

public static class AddVideoAssetToComicCommandFromResourceAssembler
{
    public static AddVideoAssetToComicCommand ToCommandFromResource(AddVideoAssetToComicResource addVideoAssetToComicResource, int comicId)
    {
        return new AddVideoAssetToComicCommand(addVideoAssetToComicResource.VideoUrl, comicId);
    }
}