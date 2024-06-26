using ChromaComics.ShoppingCarts.Domain.Models;
using ChromaComics.ShoppingCarts.Domain.Repositories;
using ChromaComics.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChromaComics.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace ChromaComics.ShoppingCarts.Persistence.Repositories
{
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly AppDbContext _context;

        public ShoppingCartRepository(AppDbContext context) : base(context)
        {
            _context = context;
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

        public void Update(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Update(shoppingCart);
        }

        public void Remove(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Remove(shoppingCart);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}