using ChromaComics.IAM.Domain.Model.Aggregates;
using ChromaComics.IAM.Interfaces.REST.Resources;

namespace ChromaComics.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
}