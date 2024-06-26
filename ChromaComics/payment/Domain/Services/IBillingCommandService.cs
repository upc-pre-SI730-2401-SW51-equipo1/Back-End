namespace ChromaComics.payment.Domain.Services;
using Model.Commands;
using Model.Aggregates;
public interface IBillingCommandService
{
    Task<Billing?> Handle(CreateBillingCommand command);
    

}