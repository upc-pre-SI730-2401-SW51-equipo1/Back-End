using ChromaComics.ShoppingCarts.Domain.Models;

namespace ChromaComics.ShoppingCarts.Domain.Repositories;

public interface IShoppingCartRepository
{
    Task<IEnumerable<ShoppingCart>> ListAsync();
    Task AddAsync(ShoppingCart shoppingCart);
    Task<ShoppingCart> FindByIdAsync(int id);
    void Update(ShoppingCart shoppingCart);
    void Remove(ShoppingCart shoppingCart);
    Task SaveChangesAsync();
}