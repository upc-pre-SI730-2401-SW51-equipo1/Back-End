namespace ChromaComics.payment.Interfaces.REST.Resources;

public record BillingResource(int Id, int? ShoppingId,string FullName, string Email, string StreetAddress,int PhoneNumber, string Status);