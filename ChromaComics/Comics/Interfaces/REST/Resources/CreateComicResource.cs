namespace ChromaComics.Comics.Interfaces.REST.Resources;

public record CreateComicResource(string Title, string Summary, int CategoryId);