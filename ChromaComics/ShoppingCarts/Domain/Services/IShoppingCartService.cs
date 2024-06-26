using ChromaComics.ShoppingCarts.Domain.Models;
using ChromaComics.ShoppingCarts.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChromaComics.ShoppingCarts.Resources;

public interface IShoppingCartService
{
    Task<IEnumerable<ShoppingCart>> ListAsync();
    Task<ShoppingCartResponse> SaveAsync(SaveShoppingCartResource resource);
    Task<ShoppingCartResponse> UpdateAsync(int id, SaveShoppingCartResource resource);
    Task<ShoppingCartResponse> DeleteAsync(int id);
    Task SaveChangesAsync();
}