using AutoMapper;
using ChromaComics.Comics.Domain.Models;
using ChromaComics.Comics.Resources;

namespace ChromaComics.Comics.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<ShoppingCart, ShoppingCartResource>();
    }
}