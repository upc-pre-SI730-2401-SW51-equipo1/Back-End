using ChromaComics.Recommendations.Domain.Models;
using ChromaComics.Recommendations.Domain.Services.Communication;

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