namespace ChromaComics.Comics.Interfaces.REST.Resources;

public record ComicResource(int Id, string Title, string Summary, CategoryResource Category, string Status);