using ChromaComics.Comics.Domain.Model.Aggregates;
using ChromaComics.Comics.Domain.Model.Commands;
using ChromaComics.Comics.Domain.Repositories;
using ChromaComics.Comics.Domain.Services;
using ChromaComics.Shared.Domain.Repositories;

namespace ChromaComics.Comics.Application.Internal.CommandServices;

public class ComicCommandService(IComicRepository comicRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : IComicCommandService
{

    public async Task<Comic?> Handle(AddVideoAssetToComicCommand command)
    {
        var comic = await comicRepository.FindByIdAsync(command.ComicId);
        if (comic is null) throw new Exception("Comic not found");
        comic.AddVideo(command.VideoUrl);
        await unitOfWork.CompleteAsync();
        return comic;
    }

    public async Task<Comic?> Handle(CreateComicCommand command)
    {
        var comic = new Comic(command.Title, command.Summary, command.CategoryId);
        await comicRepository.AddAsync(comic);
        await unitOfWork.CompleteAsync();
        var category = await categoryRepository.FindByIdAsync(command.CategoryId);
        comic.Category = category;
        return comic;
    }   
}