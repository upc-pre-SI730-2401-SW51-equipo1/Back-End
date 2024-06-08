using ChromaComics.payment.Domain.Model.Commands;
using ChromaComics.payment.Domain.Model.ValueObject;

namespace ChromaComics.payment.Domain.Model.Aggregates;

public class Billing
{
    public Billing()
    {
        Shopping = new ShoppingSummary(0,0);
        Name = new PersonName();
        Email = new EmailAddress();
        Address = new StreetAddress();
        Status = "Pending";
        PhoneNumber = 0;
    }

    public Billing(int shoppingId, decimal totalPrice, string firstName, string lastName, string email, string street,
        string number, string city, string postalCode, string country, int phoneNumber, string status)
    {
        Shopping = new ShoppingSummary( shoppingId, totalPrice);
        PhoneNumber = phoneNumber;
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        Address = new StreetAddress(street, number, city, postalCode, country);
        Status = status;
    }

    public Billing(CreateBillingCommand command)
    {
        Shopping = new ShoppingSummary(command.ShoppingId, command.TotalPrice);
        PhoneNumber = command.PhoneNumber;
        Name = new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
        Address = new StreetAddress(command.Street, command.Number, command.City, command.PostalCode, command.Country);
        Status = command.Status;
    }   
    
    public int Id { get; }
    public ShoppingSummary Shopping { get; internal set; }
    public EmailAddress Email { get; private set; }
    public PersonName Name { get; private set; }
    public StreetAddress Address { get; private set; }
    public string Status { get; private set; }
    public int PhoneNumber { get; private set; }
    public string FullName => Name.FullName;

    public string EmailAddress => Email.Address;

    public string StreetAddress => Address.FullAddress;
    
    
}