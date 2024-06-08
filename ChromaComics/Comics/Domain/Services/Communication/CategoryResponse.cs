using ChromaComics.Comics.Domain.Models;
using ChromaComics.Shared.Domain.Services.Communication;

namespace ChromaComics.Comics.Domain.Services.Communication;

public class CategoryResponse : BaseResponse<Category>
{
    public CategoryResponse(string message) : base(message)
    {
    }

    public CategoryResponse(Category resource) : base(resource)
    {
    }
}