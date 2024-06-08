using ChromaComics.Comics.Domain.Models;

namespace ChromaComics.Comics.Resources;

public class ComicResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public CategoryResource Category { get; set; }
}