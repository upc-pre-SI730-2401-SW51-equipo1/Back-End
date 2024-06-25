using AutoMapper;
using ChromaComics.ShoppingCarts.Domain.Models;
using ChromaComics.ShoppingCarts.Resources;

namespace ChromaComics.ShoppingCarts.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveShoppingCartResource, ShoppingCart>();

    }
}