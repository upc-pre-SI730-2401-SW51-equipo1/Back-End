using ChromaComics.Comics.Domain.Model.Aggregates;

namespace ChromaComics.Comics.Domain.Model.Entities;

public class Category
{
    public Category()
    {
        Name = string.Empty;
    }


    public Category(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Comic> Comics { get; }
}