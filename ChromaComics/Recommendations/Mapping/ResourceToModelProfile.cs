using AutoMapper;
using ChromaComics.Recommendations.Domain.Models;
using ChromaComics.Recommendations.Resources;

namespace ChromaComics.Recommendations.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveRecommendationResource, Recommendation>();

    }
}