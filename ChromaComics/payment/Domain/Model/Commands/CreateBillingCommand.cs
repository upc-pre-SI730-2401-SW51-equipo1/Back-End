namespace ChromaComics.payment.Domain.Model.Commands;

public record CreateBillingCommand(int ShoppingId, decimal TotalPrice,string FirstName, string LastName, string Email, string Street, string Number, string City, string PostalCode, string Country,int PhoneNumber, string Status);