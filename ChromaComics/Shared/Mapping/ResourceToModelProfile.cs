using AutoMapper;
using ChromaComics.Comics.Domain.Models;
using ChromaComics.Comics.Resources;

namespace ChromaComics.Comics.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveShoppingCartResource, ShoppingCart>();
        CreateMap<SaveRecommendationResource, Recommendation>();
        CreateMap<SaveCategoryResource, Category>();
        CreateMap<SaveComicResource, Comic>();
    }
}