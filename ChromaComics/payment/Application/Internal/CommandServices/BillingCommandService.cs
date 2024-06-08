namespace ChromaComics.payment.Application.Internal.CommandServices;
using Domain.Model.Aggregates;
using Domain.Model.Commands;
using Domain.Repositories;
using Domain.Services;
using ChromaComics.Shared.Domain.Repositories;
public class BillingCommandService(IBillingRepository billingRepository, IUnitOfWork unitOfWork): IBillingCommandService
{
    public async Task<Billing?> Handle(CreateBillingCommand command)
    {
        var billing = new Billing(command);
        try
        {
            await billingRepository.AddAsync(billing);
            await unitOfWork.CompleteAsync();
            return billing;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An Error Occured while creating Billing: {e.Message}");
            return null;
        }
        
    }
}