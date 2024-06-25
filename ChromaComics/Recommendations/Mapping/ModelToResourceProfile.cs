using AutoMapper;
using ChromaComics.Recommendations.Domain.Models;
using ChromaComics.Recommendations.Resources;

namespace ChromaComics.Recommendations.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Recommendation, RecommendationResource>();
    }
}