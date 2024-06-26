using ChromaComics.ShoppingCarts.Domain.Models;
using ChromaComics.ShoppingCarts.Domain.Services.Communication;

namespace ChromaComics.ShoppingCarts.Domain.Services.Communication;

public class ShoppingCartResponse : BaseResponse<ShoppingCart>
{
    public ShoppingCartResponse(string message) : base(message)
    {
    }

    public ShoppingCartResponse(ShoppingCart resource) : base(resource)
    {
    }
}