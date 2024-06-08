using ChromaComics.Comics.Domain.Models;
using ChromaComics.Shared.Domain.Services.Communication;

namespace ChromaComics.Comics.Domain.Services.Communication;

public class ShoppingCartResponse : BaseResponse<ShoppingCart>
{
    public ShoppingCartResponse(string message) : base(message)
    {
    }

    public ShoppingCartResponse(ShoppingCart resource) : base(resource)
    {
    }
}