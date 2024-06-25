namespace ChromaComics.Comics.Domain.Model.Entities;

public record ChromacomicsAssetIdentifier(Guid Identifier)
{
    public ChromacomicsAssetIdentifier() : this(Guid.NewGuid())
    {
    }
}