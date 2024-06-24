
using ChromaComics.Comics.Domain.Model.Aggregates;
using ChromaComics.Comics.Domain.Model.Commands;

namespace ChromaComics.Comics.Domain.Services;

public interface IComicCommandService
{
    Task<Comic?> Handle(AddVideoAssetToComicCommand command);
    Task<Comic?> Handle(CreateComicCommand command);
}