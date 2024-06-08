namespace ChromaComics.Comics.Domain.Models;

public class Recommendation
{
    public int Id { get; set; }
    public string BookTitle { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
    public string Author { get; set; }

}