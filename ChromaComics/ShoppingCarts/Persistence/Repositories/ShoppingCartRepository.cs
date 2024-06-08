using ChromaComics.Comics.Domain.Models;
using ChromaComics.Comics.Domain.Repositories;
using ChromaComics.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChromaComics.Shared.Persistence.Repositories;

public class ShoppingCartRepository : BaseRepository, IShoppingCartRepository
{
    public ShoppingCartRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ShoppingCart>> ListAsync()
    {
        return await _context.ShoppingCarts.ToListAsync();
    }

    public async Task AddAsync(ShoppingCart shoppingCart)
    {
        await _context.ShoppingCarts.AddAsync(shoppingCart);
    }

    public async Task<ShoppingCart> FindByIdAsync(int id)
    {
        return await _context.ShoppingCarts.FindAsync(id);
    }

    public void Update(ShoppingCart shoppingcart)
    {
        _context.ShoppingCarts.Update(shoppingcart);
    }

    public void Remove(ShoppingCart shoppingcart)
    {
        _context.ShoppingCarts.Remove(shoppingcart);
    }
}