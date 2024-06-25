
using ChromaComics.Comics.Domain.Model.Entities;
using ChromaComics.Comics.Domain.Model.Queries;

namespace ChromaComics.Comics.Domain.Services;

public interface ICategoryQueryService
{
    Task<Category?> Handle(GetCategoryByIdQuery query);
    Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query);
}