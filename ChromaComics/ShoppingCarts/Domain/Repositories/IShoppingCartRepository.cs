using ChromaComics.ShoppingCarts.Domain.Models;

namespace ChromaComics.ShoppingCarts.Domain.Repositories;

public interface IShoppingCartRepository
{
    Task<IEnumerable<ShoppingCart>> ListAsync();
    Task AddAsync(ShoppingCart shoppingcart);
    Task<ShoppingCart> FindByIdAsync(int id);
    void Update(ShoppingCart shoppingcart);
    void Remove(ShoppingCart shoppingcart);

}