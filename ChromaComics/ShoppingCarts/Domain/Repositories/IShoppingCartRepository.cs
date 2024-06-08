using ChromaComics.Comics.Domain.Models;

namespace ChromaComics.Comics.Domain.Repositories;

public interface IShoppingCartRepository
{
    Task<IEnumerable<ShoppingCart>> ListAsync();
    Task AddAsync(ShoppingCart shoppingcart);
    Task<ShoppingCart> FindByIdAsync(int id);
    void Update(ShoppingCart shoppingcart);
    void Remove(ShoppingCart shoppingcart);

}