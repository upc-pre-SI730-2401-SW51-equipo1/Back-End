namespace ChromaComics.payment.Domain.Model.ValueObject;

public record ShoppingSummary(int? ShoppingId, decimal? TotalPrice)
{
    public ShoppingSummary() : this(0, 0)
    {
    }
    public ShoppingSummary(int? shoppingId) : this(shoppingId, 0)
    {
    }

    public string FullShoppingSummary => $"{ShoppingId} {TotalPrice}";


};