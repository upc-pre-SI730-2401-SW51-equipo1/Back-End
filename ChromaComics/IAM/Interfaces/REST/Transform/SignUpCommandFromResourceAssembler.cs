using ChromaComics.IAM.Domain.Model.Commands;
using ChromaComics.IAM.Interfaces.REST.Resources;

namespace ChromaComics.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password,resource.CellphoneNumber);
    }
}