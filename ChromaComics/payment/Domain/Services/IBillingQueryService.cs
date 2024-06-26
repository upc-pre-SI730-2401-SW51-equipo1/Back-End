namespace ChromaComics.payment.Domain.Services;
using Model.Aggregates;
using Model.Queries;

public interface IBillingQueryService
{
    Task<IEnumerable<Billing>> Handle(GetAllBillingQuery query);
    Task<Billing?> Handle(GetAllBillingQueryById query);
    Task<Billing?> Handle(GetBillingByShoppingIdQuery query);
}