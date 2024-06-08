using ChromaComics.Comics.Domain.Models;
using ChromaComics.Comics.Domain.Repositories;
using ChromaComics.Comics.Domain.Services;
using ChromaComics.Comics.Domain.Services.Communication;

namespace ChromaComics.Comics.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingcartRepository;

    public ShoppingCartService(IShoppingCartRepository shoppingcartRepository)
    {
        _shoppingcartRepository = shoppingcartRepository;
    }   

    public async Task<IEnumerable<ShoppingCart>> ListAsync()
    {
        return await _shoppingcartRepository.ListAsync();
    }

    public async Task<ShoppingCartResponse> SaveAsync(ShoppingCart shoppingcart)
    {
        try
        {
            await _shoppingcartRepository.AddAsync(shoppingcart);
            return new ShoppingCartResponse(shoppingcart);
        }
        catch (Exception e)
        {
            return new ShoppingCartResponse($"An error occurred while saving the cart: {e.Message}");
        }
    }

    public async Task<ShoppingCartResponse> UpdateAsync(int id, ShoppingCart shoppingcart)
    {
        var existingShoppingCart = await _shoppingcartRepository.FindByIdAsync(id);

        if (existingShoppingCart == null)
            return new ShoppingCartResponse("Cart not found.");

        existingShoppingCart.Id = shoppingcart.Id;

        try
        {
            _shoppingcartRepository.Update(existingShoppingCart);
            return new ShoppingCartResponse(existingShoppingCart);
        }
        catch (Exception e)
        {
            return new ShoppingCartResponse($"An error occurred while updating the cart: {e.Message}");
        }
    }

    public async Task<ShoppingCartResponse> DeleteAsync(int id)
    {
        var existingShoppingCart = await _shoppingcartRepository.FindByIdAsync(id);

        if (existingShoppingCart == null)
            return new ShoppingCartResponse("Cart not found.");

        try
        {
            _shoppingcartRepository.Remove(existingShoppingCart);

            return new ShoppingCartResponse(existingShoppingCart);
        }
        catch (Exception e)
        {

            return new ShoppingCartResponse($"An error occurred while deleting the cart: {e.Message}");
        }
    }
}