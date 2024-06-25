namespace ChromaComics.Comics.Domain.Model.Commands;

public record AddVideoAssetToComicCommand(string VideoUrl, int ComicId);