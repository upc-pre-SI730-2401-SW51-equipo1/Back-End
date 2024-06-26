namespace ChromaComics.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}