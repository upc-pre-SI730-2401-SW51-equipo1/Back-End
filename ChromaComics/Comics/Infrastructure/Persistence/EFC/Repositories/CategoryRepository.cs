using ChromaComics.Comics.Domain.Model.Entities;
using ChromaComics.Comics.Domain.Repositories;
using ChromaComics.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChromaComics.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ChromaComics.Comics.Infrastructure.Persistence.EFC.Repositories;

public class CategoryRepository(AppDbContext context) : BaseRepository<Category>(context), ICategoryRepository;