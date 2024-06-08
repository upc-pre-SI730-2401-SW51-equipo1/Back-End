using AutoMapper;
using ChromaComics.Comics.Domain.Models;
using ChromaComics.Comics.Domain.Services;
using ChromaComics.Comics.Resources;
using ChromaComics.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ChromaComics.Comics.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ComicsController : ControllerBase
{
    private readonly IComicService _comicService;
    private readonly IMapper _mapper;

    public ComicsController(IComicService comicService, IMapper mapper)
    {
        _comicService = comicService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ComicResource>> GetAllAsync()
    {
        var comics = await _comicService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Comic>, IEnumerable<ComicResource>>(comics);

        return resources;

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveComicResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var comic = _mapper.Map<SaveComicResource, Comic>(resource);

        var result = await _comicService.SaveAsync(comic);

        if (!result.Success)
            return BadRequest(result.Message);

        var comicResource = _mapper.Map<Comic, ComicResource>(result.Resource);

        return Ok(comicResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveComicResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var comic = _mapper.Map<SaveComicResource, Comic>(resource);

        var result = await _comicService.UpdateAsync(id, comic);

        if (!result.Success)
            return BadRequest(result.Message);

        var comicResource = _mapper.Map<Comic, ComicResource>(result.Resource);

        return Ok(comicResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _comicService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var comicResource = _mapper.Map<Comic, ComicResource>(result.Resource);

        return Ok(comicResource);
    }

}