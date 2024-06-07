using System.ComponentModel.DataAnnotations;

namespace ChromaComics.Comics.Resources;

public class SaveComicResource
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    
    [MaxLength(120)]
    public string Description { get; set; }
    
    [Required]
    public int CategoryId { get; set; }
}