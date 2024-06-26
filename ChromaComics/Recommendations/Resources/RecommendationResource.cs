namespace ChromaComics.Recommendations.Resources
{
    public class RecommendationResource
    {
        public int Id { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}