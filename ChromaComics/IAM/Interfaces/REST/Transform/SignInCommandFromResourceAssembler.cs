using ChromaComics.IAM.Domain.Model.Commands;
using ChromaComics.IAM.Interfaces.REST.Resources;

namespace ChromaComics.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}