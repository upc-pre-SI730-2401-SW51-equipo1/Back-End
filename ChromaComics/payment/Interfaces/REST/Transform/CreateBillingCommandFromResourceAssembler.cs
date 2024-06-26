using ChromaComics.payment.Domain.Model.Commands;
using ChromaComics.payment.Interfaces.REST.Resources;

namespace ChromaComics.payment.Interfaces.REST.Transform;

public static class CreateBillingCommandFromResourceAssembler
{
    public static CreateBillingCommand ToCommandFromResource(this CreateBillingResource resource)
    {
        return new CreateBillingCommand(resource.ShoppingId, resource.TotalPrice, resource.FirstName, resource.LastName, resource.Email, resource.Street, resource.Number, resource.City, resource.PostalCode, resource.Country, resource.PhoneNumber, resource.Status);
    }
    
}