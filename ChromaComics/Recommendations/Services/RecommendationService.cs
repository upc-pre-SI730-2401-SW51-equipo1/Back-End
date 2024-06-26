using ChromaComics.Recommendations.Domain.Models;
using ChromaComics.Recommendations.Domain.Repositories;
using ChromaComics.Recommendations.Domain.Services;
using Comm = ChromaComics.Recommendations.Domain.Services.Communication; // Alias para evitar ambigüedad
using ChromaComics.Recommendations.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChromaComics.Recommendations.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IRecommendationRepository _recommendationRepository;

        public RecommendationService(IRecommendationRepository recommendationRepository)
        {
            _recommendationRepository = recommendationRepository;
        }

        public async Task<IEnumerable<Recommendation>> ListAsync()
        {
            return await _recommendationRepository.ListAsync();
        }

        public async Task<Comm.RecommendationResponse> SaveAsync(SaveRecommendationResource resource)
        {
            try
            {
                var recommendation = new Recommendation
                {
                    BookTitle = resource.BookTitle,
                    Description = resource.Description,
                    Genre = resource.Genre,
                    Author = resource.Author
                };
                await _recommendationRepository.AddAsync(recommendation);
                return new Comm.RecommendationResponse(recommendation);
            }
            catch (Exception ex)
            {
                return new Comm.RecommendationResponse($"An error occurred when saving the recommendation: {ex.Message}");
            }
        }

        public async Task<Comm.RecommendationResponse> UpdateAsync(int id, SaveRecommendationResource resource)
        {
            var existingRecommendation = await _recommendationRepository.FindByIdAsync(id);

            if (existingRecommendation == null)
                return new Comm.RecommendationResponse("Recommendation not found.");

            existingRecommendation.BookTitle = resource.BookTitle;
            existingRecommendation.Description = resource.Description;
            existingRecommendation.Genre = resource.Genre;
            existingRecommendation.Author = resource.Author;

            try
            {
                _recommendationRepository.Update(existingRecommendation);
                return new Comm.RecommendationResponse(existingRecommendation);
            }
            catch (Exception ex)
            {
                return new Comm.RecommendationResponse($"An error occurred when updating the recommendation: {ex.Message}");
            }
        }

        public async Task<Comm.RecommendationResponse> DeleteAsync(int id)
        {
            var existingRecommendation = await _recommendationRepository.FindByIdAsync(id);

            if (existingRecommendation == null)
                return new Comm.RecommendationResponse("Recommendation not found.");

            try
            {
                _recommendationRepository.Remove(existingRecommendation);
                return new Comm.RecommendationResponse(existingRecommendation);
            }
            catch (Exception ex)
            {
                return new Comm.RecommendationResponse($"An error occurred when deleting the recommendation: {ex.Message}");
            }
        }
    }
}