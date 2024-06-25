
using ChromaComics.Comics.Domain.Model.Queries;
using ChromaComics.Comics.Domain.Services;
using ChromaComics.Comics.Interfaces.REST.Resources;
using ChromaComics.Comics.Interfaces.REST.Transform;
using ChromaComics.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace ChromaComics.Comics.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ComicsController(
    IComicCommandService comicCommandService,
    IComicQueryService comicQueryService)
    : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateComic([FromBody] CreateComicResource createComicResource)
    {
        var createComicCommand =
            CreateComicCommandFromResourceAssembler.ToCommandFromResource(createComicResource);
        var comic = await comicCommandService.Handle(createComicCommand);
        if (comic is null) return BadRequest();
        var resource = ComicResourceFromEntityAssembler.ToResourceFromEntity(comic);
        return CreatedAtAction(nameof(GetComicById), new { comicId = resource.Id }, resource);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllComics()
    {
        var getAllComicsQuery = new GetAllComicsQuery();
        var comics = await comicQueryService.Handle(getAllComicsQuery);
        var resources = comics.Select(ComicResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{comicId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetComicById([FromRoute] int comicId)
    {
        var comic = await comicQueryService.Handle(new GetComicByIdQuery(comicId));
        if (comic == null) return NotFound();
        var resource = ComicResourceFromEntityAssembler.ToResourceFromEntity(comic);
        return Ok(resource);
    }
}