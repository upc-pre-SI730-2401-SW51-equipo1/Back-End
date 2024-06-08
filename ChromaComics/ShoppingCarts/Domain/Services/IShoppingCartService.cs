using ChromaComics.Comics.Domain.Models;
using ChromaComics.Comics.Domain.Services.Communication;

namespace ChromaComics.Comics.Domain.Services;

public interface IShoppingCartService
{
    Task<IEnumerable<ShoppingCart>> ListAsync();
    Task<ShoppingCartResponse> SaveAsync(ShoppingCart shoppingcart);
    Task<ShoppingCartResponse> UpdateAsync(int id, ShoppingCart shoppingcart);
    Task<ShoppingCartResponse> DeleteAsync(int id);
}