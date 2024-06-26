using ChromaComics.payment.Domain.Model.Aggregates;
using ChromaComics.payment.Domain.Model.Queries;
using ChromaComics.payment.Domain.Repositories;
using ChromaComics.payment.Domain.Services;
using ChromaComics.Shared.Domain.Repositories;

namespace ChromaComics.payment.Application.Internal.QueryServices;

public class BillingQueryService(IBillingRepository billingRepository): IBillingQueryService
{
    public async Task<IEnumerable<Billing>> Handle(GetAllBillingQuery query)
    {
        return await billingRepository.ListAsync();
    }

    public async  Task<Billing?> Handle(GetAllBillingQueryById query)
    {
        return await billingRepository.FindByIdAsync(query.Id);
    }

    public async Task<Billing?> Handle(GetBillingByShoppingIdQuery query)
    {
        return await billingRepository.FindByShoppingIdAsync(query.Id);
    }
}