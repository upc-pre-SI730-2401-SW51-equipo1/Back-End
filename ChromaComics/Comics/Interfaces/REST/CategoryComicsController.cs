
using System.Net.Mime;
using ChromaComics.Comics.Domain.Model.Queries;
using ChromaComics.Comics.Domain.Services;
using ChromaComics.Comics.Interfaces.REST.Transform;
using ChromaComics.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace ChromaComics.Comics.Interfaces.REST;

[ApiController]
[Route("/api/v1/categories/{categoryId}/comics")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Categories")]
public class CategoryComicsController(IComicQueryService comicQueryService) : ControllerBase
{
    /**
     * Get Comics by Category Id.
     * <summary>
     *     Get Comics for a given category.
     * </summary>
     * <param name="categoryId">Category Id</param>
     * <returns>Comic Resources</returns>
     */
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetComicsByCategoryId([FromRoute] int categoryId)
    {
        var getAllComicsByCategoryIdQuery = new GetAllComicsByCategoryIdQuery(categoryId);
        var comics = await comicQueryService.Handle(getAllComicsByCategoryIdQuery);
        var resources = comics.Select(ComicResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}