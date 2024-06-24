
using ChromaComics.Comics.Domain.Model.Aggregates;
using ChromaComics.Comics.Domain.Model.Queries;
using ChromaComics.Comics.Domain.Repositories;
using ChromaComics.Comics.Domain.Services;

namespace ChromaComics.Comics.Application.Internal.QueryServices;

public class ComicQueryService(IComicRepository comicRepository) : IComicQueryService
{
    /**
     * <summary>
     *     This method is responsible for handling GetComicByIdentifierQuery
     * </summary>
     * <param name="query">GetComicByIdentifierQuery>Contains the Id of the Comic</param>
     * <returns>Comic - The Comic object</returns>
     */
    public async Task<Comic?> Handle(GetComicByIdQuery query)
    {
        return await comicRepository.FindByIdAsync(query.ComicId);
    }

    /**
     * <summary>
     *     This method is responsible for handling GetAllComicsQuery
     * </summary>
     * <param name="query">GetAllComicsQuery</param>
     * <returns>IEnumerable of Comics - The list of Comic objects</returns>
     */
    public async Task<IEnumerable<Comic>> Handle(GetAllComicsQuery query)
    {
        return await comicRepository.ListAsync();
    }
    
    /**
     * <summary>
     *     This method is responsible for handling GetAllComicsByCategoryIdQuery
     * </summary>
     * <param name="query">GetAllComicsByCategoryIdQuery</param>
     * <returns>IEnumerable of Comics - The list of Comic objects</returns>
     */
    public async Task<IEnumerable<Comic>> Handle(GetAllComicsByCategoryIdQuery query)
    {
        return await comicRepository.FindByCategoryIdAsync(query.CategoryId);
    }
}