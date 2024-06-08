using ChromaComics.Comics.Domain.Models;
using ChromaComics.Shared.Domain.Services.Communication;

namespace ChromaComics.Comics.Domain.Services.Communication;

public class RecommendationResponse : BaseResponse<Recommendation>
{
    public RecommendationResponse(string message) : base(message)
    {
    }

    public RecommendationResponse(Recommendation resource) : base(resource)
    {
    }
}