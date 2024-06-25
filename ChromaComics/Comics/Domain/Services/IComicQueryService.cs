
using ChromaComics.Comics.Domain.Model.Aggregates;
using ChromaComics.Comics.Domain.Model.Queries;

namespace ChromaComics.Comics.Domain.Services;

public interface IComicQueryService
{
    Task<Comic?> Handle(GetComicByIdQuery query);
    Task<IEnumerable<Comic>> Handle(GetAllComicsQuery query);
    Task<IEnumerable<Comic>> Handle(GetAllComicsByCategoryIdQuery query);
}