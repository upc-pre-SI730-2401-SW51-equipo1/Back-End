using System.Net.Mime;
using ChromaComics.payment.Domain.Model.Queries;
using ChromaComics.payment.Domain.Services;
using ChromaComics.payment.Interfaces.REST.Resources;
using ChromaComics.payment.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ChromaComics.payment.Interfaces.REST;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BillingController(IBillingCommandService billingCommandService, IBillingQueryService billingQueryService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateBilling([FromBody] CreateBillingResource resource)
    {
        var createBillingCommand = CreateBillingCommandFromResourceAssembler.ToCommandFromResource(resource);
        var billing = await billingCommandService.Handle(createBillingCommand);
        if (billing == null)
        {
            return BadRequest();
        }
        var billingResource = BillingResourceFromEntityAssembler.ToResourceFromEntity(billing);
        return CreatedAtAction(nameof(GetBillingById), new {billingId = billingResource.Id}, billingResource);
       }
    

    [HttpGet]
    public async Task<IActionResult> GetAllBilling()
    {
        var getAllBillingQuery = new GetAllBillingQuery();
        var billing = await billingQueryService.Handle(getAllBillingQuery);
        var billingResource = billing.Select(BillingResourceFromEntityAssembler.ToResourceFromEntity);
        
        return Ok(billingResource);
    }

    [HttpGet("{billingId:int}")]
    public async Task<IActionResult> GetBillingById(int billingId)
    {
        var billing = await billingQueryService.Handle(new GetAllBillingQueryById(billingId));
        if (billing == null)
        {
            return NotFound();
        }
        var billingResource = BillingResourceFromEntityAssembler.ToResourceFromEntity(billing);
        return Ok(billingResource);

    }

    [HttpGet("shopping/{shoppingId:int}")]
    public async Task<IActionResult> GetBillingByShoppingId(int shoppingId)
    {
        var billing = await billingQueryService.Handle(new GetBillingByShoppingIdQuery(shoppingId));
        if (billing == null)
        {
            return NotFound();
        }
        var billingResource = BillingResourceFromEntityAssembler.ToResourceFromEntity(billing);
        return Ok(billingResource);
    }

    
    
}