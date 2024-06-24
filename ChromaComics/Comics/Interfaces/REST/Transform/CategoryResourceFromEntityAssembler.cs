
using ChromaComics.Comics.Domain.Model.Entities;
using ChromaComics.Comics.Interfaces.REST.Resources;

namespace ChromaComics.Comics.Interfaces.REST.Transform;

public static class CategoryResourceFromEntityAssembler
{
    public static CategoryResource ToResourceFromEntity(Category entity)
    {
        Console.WriteLine("Category Name is " + entity.Name);
        return new CategoryResource(entity.Id, entity.Name);
    }
}