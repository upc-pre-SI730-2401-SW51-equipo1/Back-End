namespace ChromaComics.Comics.Domain.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Relation of Category to Comic
    public IList<Comic> Comics { get; set; } = new List<Comic>();
}
