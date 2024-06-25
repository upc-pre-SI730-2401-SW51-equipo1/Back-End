namespace ChromaComics.payment.Domain.Repositories;
using Model.Aggregates;
using ChromaComics.Shared.Domain.Repositories;
public interface IBillingRepository : IBaseRepository<Billing>
{
    Task<IEnumerable<Billing>> FindByBillingIdAsync(int billingId);
    Task<Billing?> FindByShoppingIdAsync(int shoppingId);
    
    
}