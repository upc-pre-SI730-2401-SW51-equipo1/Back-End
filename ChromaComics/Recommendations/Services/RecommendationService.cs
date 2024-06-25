using ChromaComics.Recommendations.Domain.Models;
using ChromaComics.Recommendations.Domain.Repositories;
using ChromaComics.Recommendations.Domain.Services;
using ChromaComics.Recommendations.Domain.Services.Communication;

namespace ChromaComics.Recommendations.Services;

public class RecommendationService : IRecommendationService
{
    private readonly IRecommendationRepository _shoppingcartRepository;

    public RecommendationService(IRecommendationRepository shoppingcartRepository)
    {
        _shoppingcartRepository = shoppingcartRepository;
    }   

    public async Task<IEnumerable<Recommendation>> ListAsync()
    {
        return await _shoppingcartRepository.ListAsync();
    }

    public async Task<RecommendationResponse> SaveAsync(Recommendation shoppingcart)
    {
        try
        {
            await _shoppingcartRepository.AddAsync(shoppingcart);
            return new RecommendationResponse(shoppingcart);
        }
        catch (Exception e)
        {
            return new RecommendationResponse($"An error occurred while saving the cart: {e.Message}");
        }
    }

    public async Task<RecommendationResponse> UpdateAsync(int id, Recommendation shoppingcart)
    {
        var existingShoppingCart = await _shoppingcartRepository.FindByIdAsync(id);

        if (existingShoppingCart == null)
            return new RecommendationResponse("Cart not found.");

        existingShoppingCart.Id = shoppingcart.Id;

        try
        {
            _shoppingcartRepository.Update(existingShoppingCart);
            return new RecommendationResponse(existingShoppingCart);
        }
        catch (Exception e)
        {
            return new RecommendationResponse($"An error occurred while updating the cart: {e.Message}");
        }
    }

    public async Task<RecommendationResponse> DeleteAsync(int id)
    {
        var existingShoppingCart = await _shoppingcartRepository.FindByIdAsync(id);

        if (existingShoppingCart == null)
            return new RecommendationResponse("Cart not found.");

        try
        {
            _shoppingcartRepository.Remove(existingShoppingCart);

            return new RecommendationResponse(existingShoppingCart);
        }
        catch (Exception e)
        {

            return new RecommendationResponse($"An error occurred while deleting the cart: {e.Message}");
        }
    }
}