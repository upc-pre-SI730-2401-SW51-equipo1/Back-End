﻿using ChromaComics.Comics.Domain.Models;

namespace ChromaComics.Comics.Domain.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> ListAsync();
    Task AddAsync(Category category);
    Task<Category> FindByIdAsync(int id);
    void Update(Category category);
    void Remove(Category category);

}