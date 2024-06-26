﻿using ChromaComics.Recommendations.Domain.Services.Communication;
using ChromaComics.Recommendations.Models;

namespace ChromaComics.Recommendations.Domain.Services.Communication;

public class RecommendationResponse : BaseResponse<Recommendation>
{
    public RecommendationResponse(string message) : base(message)
    {
    }

    public RecommendationResponse(Recommendation resource) : base(resource)
    {
    }
}