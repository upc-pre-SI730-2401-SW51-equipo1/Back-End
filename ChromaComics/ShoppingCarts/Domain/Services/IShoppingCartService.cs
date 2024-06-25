using ChromaComics.ShoppingCarts.Domain.Models;
using ChromaComics.ShoppingCarts.Domain.Services.Communication;

namespace ChromaComics.ShoppingCarts.Domain.Services;

public interface IShoppingCartService
{
    Task<IEnumerable<ShoppingCart>> ListAsync();
    Task<ShoppingCartResponse> SaveAsync(ShoppingCart shoppingcart);
    Task<ShoppingCartResponse> UpdateAsync(int id, ShoppingCart shoppingcart);
    Task<ShoppingCartResponse> DeleteAsync(int id);
}