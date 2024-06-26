namespace ChromaComics.payment.Infrastructure.Repositories;
using ChromaComics.Shared.Infrastructure.Persistence.EFC.Repositories;
using ChromaComics.Shared.Infrastructure.Persistence.EFC.Configuration;
using Domain.Model.Aggregates;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
public class BillingRepository(AppDbContext context): BaseRepository<Billing>(context), IBillingRepository
{
    public async Task<IEnumerable<Billing>> FindByBillingIdAsync(int billingId)
    {
        return await Context.Set<Billing>().Where(b => b.Id == billingId).ToListAsync();
    }

    public Task<Billing?> FindByShoppingIdAsync(int shoppingId)
    {
        return  Context.Set<Billing>().Where(b => b.Shopping.ShoppingId == shoppingId).FirstOrDefaultAsync();
    }
}