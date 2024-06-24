namespace ChromaComics.Comics.Domain.Model.Commands;

public record CreateComicCommand(string Title, string Summary, int CategoryId);