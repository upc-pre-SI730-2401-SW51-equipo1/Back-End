namespace ChromaComics.Recommendations.Resources
{
    public class SaveRecommendationResource
    {
        public int Id { get; set; } // Añadir campo de ID
        public string BookTitle { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; } // Añadir campo de imagen
    }
}