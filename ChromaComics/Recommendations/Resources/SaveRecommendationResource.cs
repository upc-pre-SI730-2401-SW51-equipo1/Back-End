﻿namespace ChromaComics.Recommendations.Resources
{
    public class SaveRecommendationResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Issue { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public string Writer { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
    }
}