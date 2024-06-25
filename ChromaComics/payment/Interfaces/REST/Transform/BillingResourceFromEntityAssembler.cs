using ChromaComics.payment.Domain.Model.Aggregates;
using ChromaComics.payment.Interfaces.REST.Resources;

namespace ChromaComics.payment.Interfaces.REST.Transform;

public static class BillingResourceFromEntityAssembler
{
    public static BillingResource ToResourceFromEntity(this Billing entity) => new BillingResource(entity.Id, entity.Shopping.ShoppingId, entity.FullName, entity.EmailAddress, entity.StreetAddress, entity.PhoneNumber, entity.Status);
    
}