using ChromaComics.ShoppingCarts.Domain.Models;
using ChromaComics.ShoppingCarts.Domain.Services;
using ChromaComics.ShoppingCarts.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChromaComics.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace ChromaComics.ShoppingCarts.Controllers
{
    [Route("/api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ShoppingCartResource>> GetAllAsync()
        {
            var shoppingcarts = await _shoppingCartService.ListAsync();
            var resources = new List<ShoppingCartResource>();
            foreach (var shoppingCart in shoppingcarts)
            {
                resources.Add(new ShoppingCartResource
                {
                    Id = shoppingCart.Id,
                    ProductId = shoppingCart.ProductId,
                });
            }
            return resources;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] SaveShoppingCartResource resource)
        {
            var result = await _shoppingCartService.SaveAsync(resource);

            if (!result.Success)
                return BadRequest(result.Message);

            var shoppingCartResource = new ShoppingCartResource
            { 
                Id = result.Resource.Id,
                ProductId = result.Resource.ProductId,
            };
            return Ok(shoppingCartResource);
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _shoppingCartService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var shoppingCartResource = new ShoppingCartResource
            {
                Id = result.Resource.Id,
                ProductId = result.Resource.ProductId,
            };
            return Ok(shoppingCartResource);
        }
    }
}