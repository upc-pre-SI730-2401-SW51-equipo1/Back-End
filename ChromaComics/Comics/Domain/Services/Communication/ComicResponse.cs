using ChromaComics.Comics.Domain.Models;
using ChromaComics.Shared.Domain.Services.Communication;

namespace ChromaComics.Comics.Domain.Services.Communication;

public class ComicResponse : BaseResponse<Comic>
{
    public ComicResponse(string message) : base(message)
    {
    }

    public ComicResponse(Comic resource) : base(resource)
    {
    }
}