using ChromaComics.IAM.Domain.Model.Aggregates;
using ChromaComics.IAM.Interfaces.REST.Resources;

namespace ChromaComics.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username);
    }
}