using AutoMapper;
using ChromaComics.Comics.Domain.Models;
using ChromaComics.Comics.Domain.Services;
using ChromaComics.Comics.Resources;
using ChromaComics.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ChromaComics.Comics.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ShoppingCartsController : ControllerBase
{
    private readonly IShoppingCartService _shoppingcartService;
    private readonly IMapper _mapper;
    

    public ShoppingCartsController(IShoppingCartService shoppingcartService, IMapper mapper)
    {
        _shoppingcartService = shoppingcartService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ShoppingCartResource>> GetAllAsync()
    {
        var shoppingcarts = await _shoppingcartService.ListAsync();
        var resources = _mapper.Map<IEnumerable<ShoppingCart>, IEnumerable<ShoppingCartResource>>(shoppingcarts);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveShoppingCartResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var shoppingcart = _mapper.Map<SaveShoppingCartResource, ShoppingCart>(resource);

        var result = await _shoppingcartService.SaveAsync(shoppingcart);

        if (!result.Success)
            return BadRequest(result.Message);

        var shoppingcartResource = _mapper.Map<ShoppingCart, ShoppingCartResource>(result.Resource);

        return Ok(shoppingcartResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveShoppingCartResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var shoppingcart = _mapper.Map<SaveShoppingCartResource, ShoppingCart>(resource);
        var result = await _shoppingcartService.UpdateAsync(id, shoppingcart);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var shoppingcartResource = _mapper.Map<ShoppingCart, ShoppingCartResource>(result.Resource);

        return Ok(shoppingcartResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _shoppingcartService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var shoppingcartResource = _mapper.Map<ShoppingCart, ShoppingCartResource>(result.Resource);

        return Ok(shoppingcartResource);
    }
    
}