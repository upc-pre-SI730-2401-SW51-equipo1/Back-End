﻿using ChromaComics.Recommendations.Domain.Models;
using ChromaComics.Recommendations.Domain.Repositories;
using ChromaComics.Recommendations.Domain.Services;
using Comm = ChromaComics.Recommendations.Domain.Services.Communication; // Alias para evitar ambigüedad
using ChromaComics.Recommendations.Resources;
using ChromaComics.Shared.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ChromaComics.Recommendations.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IRecommendationRepository _recommendationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly HttpClient _httpClient;

        public RecommendationService(IRecommendationRepository recommendationRepository, IUnitOfWork unitOfWork, HttpClient httpClient)
        {
            _recommendationRepository = recommendationRepository;
            _unitOfWork = unitOfWork;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Recommendation>> ListAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:3000/comics");
            response.EnsureSuccessStatusCode();

            var recommendations = await response.Content.ReadFromJsonAsync<List<Recommendation>>();
            return recommendations;
        }

        public async Task<Comm.RecommendationResponse> SaveAsync(SaveRecommendationResource resource)
        {
            try
            {
                var recommendation = new Recommendation
                {
                    Id = resource.Id,
                    BookTitle = resource.BookTitle,
                    Description = resource.Description,
                    Genre = resource.Genre,
                    Author = resource.Author,
                    ImageUrl = resource.ImageUrl
                };

                await _recommendationRepository.AddAsync(recommendation);
                await _unitOfWork.CompleteAsync();

                var postResponse = await _httpClient.PostAsJsonAsync("http://localhost:3000/comics", recommendation);
                postResponse.EnsureSuccessStatusCode();

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
            existingRecommendation.ImageUrl = resource.ImageUrl;

            try
            {
                _recommendationRepository.Update(existingRecommendation);
                await _unitOfWork.CompleteAsync();
                return new Comm.RecommendationResponse(existingRecommendation);
            }
            catch (Exception ex)
            {
                return new Comm.RecommendationResponse($"An error occurred when updating the recommendation: {ex.Message}");
            }
        }

        public async Task<Comm.RecommendationResponse> DeleteAsync(int id)
        {
            try
            {
                var existingRecommendation = await _recommendationRepository.FindByIdAsync(id);

                if (existingRecommendation == null)
                {
                    Console.WriteLine($"Recommendation with ID {id} not found in the local database.");
                    return new Comm.RecommendationResponse("Recommendation not found.");
                }

                _recommendationRepository.Remove(existingRecommendation);
                await _unitOfWork.CompleteAsync();

                var deleteResponse = await _httpClient.DeleteAsync($"http://localhost:3000/comics/{id}");
                if (!deleteResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Failed to delete recommendation with ID {id} from JSON Server.");
                    return new Comm.RecommendationResponse($"Failed to delete recommendation from JSON Server.");
                }

                return new Comm.RecommendationResponse(existingRecommendation);
            }
            catch (Exception ex)
            {
                return new Comm.RecommendationResponse($"An error occurred when deleting the recommendation: {ex.Message}");
            }
        }
    }
}