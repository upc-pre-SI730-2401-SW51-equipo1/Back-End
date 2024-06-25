using AutoMapper;
using ChromaComics.ShoppingCarts.Domain.Models;
using ChromaComics.ShoppingCarts.Resources;

namespace ChromaComics.ShoppingCarts.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<ShoppingCart, ShoppingCartResource>();
    }
}