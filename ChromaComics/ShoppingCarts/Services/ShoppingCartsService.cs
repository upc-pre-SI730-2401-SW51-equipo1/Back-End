using ChromaComics.ShoppingCarts.Domain.Models;
using ChromaComics.ShoppingCarts.Domain.Repositories;
using ChromaComics.ShoppingCarts.Domain.Services;
using Chroma = ChromaComics.ShoppingCarts.Domain.Services.Communication; 
using ChromaComics.ShoppingCarts.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChromaComics.ShoppingCarts.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<IEnumerable<ShoppingCart>> ListAsync()
        {
            return await _shoppingCartRepository.ListAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _shoppingCartRepository.SaveChangesAsync();
        }

        public async Task<Chroma.ShoppingCartResponse> SaveAsync(SaveShoppingCartResource resource)
        {
            try
            {
                var shoppingCart = new ShoppingCart
                {
                    ProductId = resource.ProductId
                };
                await _shoppingCartRepository.AddAsync(shoppingCart);
                await _shoppingCartRepository.SaveChangesAsync();
                return new Chroma.ShoppingCartResponse(shoppingCart);
            }
            catch (Exception ex)
            {
                return new Chroma.ShoppingCartResponse($"An error occurred when saving the cart: {ex.Message}");
            }
        }

        public async Task<Chroma.ShoppingCartResponse> UpdateAsync(int id, SaveShoppingCartResource resource)
        {
            var existingShoppingCart = await _shoppingCartRepository.FindByIdAsync(id);

            if (existingShoppingCart == null)
                return new Chroma.ShoppingCartResponse("Cart not found.");

            existingShoppingCart.ProductId = resource.ProductId;

            try
            {
                _shoppingCartRepository.Update(existingShoppingCart);
                return new Chroma.ShoppingCartResponse(existingShoppingCart);
            }
            catch (Exception ex)
            {
                return new Chroma.ShoppingCartResponse($"An error occurred when updating the cart: {ex.Message}");
            }
        }

        public async Task<Chroma.ShoppingCartResponse> DeleteAsync(int id)
        {
            var existingShoppingCart = await _shoppingCartRepository.FindByIdAsync(id);

            if (existingShoppingCart == null)
                return new Chroma.ShoppingCartResponse("Cart not found.");

            try
            {
                _shoppingCartRepository.Remove(existingShoppingCart);
                return new Chroma.ShoppingCartResponse(existingShoppingCart);
            }
            catch (Exception ex)
            {
                return new Chroma.ShoppingCartResponse($"An error occurred when deleting the cart: {ex.Message}");
            }
        }
    }
}