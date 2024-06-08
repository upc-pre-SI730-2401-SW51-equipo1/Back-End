namespace ChromaComics.Comics.Domain.Models;

public class Comic
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    // Relation of Comic to Category
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}