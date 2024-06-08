namespace ChromaComics.payment.Domain.Model.ValueObject;

public record EmailAddress(string Address)
{
    public EmailAddress() : this(string.Empty)
    {
    }
    
}