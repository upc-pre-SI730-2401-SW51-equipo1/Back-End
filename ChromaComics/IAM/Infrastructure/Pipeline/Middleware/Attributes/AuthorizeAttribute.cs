using ChromaComics.IAM.Domain.Model.Aggregates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChromaComics.IAM.Infrastructure.Pipeline.Middleware.Attributes;

/**
 * This attribute is used to decorate controllers and actions that require authorization.
 * It checks if the user is logged in by checking if HttpContext.User is set.
 * If user is not logged in then it returns 401 status code.
 */
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    /**
     * <summary>
     *     This method is called when authorization is required.
     *     It checks if the user is logged in by checking if HttpContext.User is set.
     *     If user is not logged in then it returns 401 status code.
     * </summary>
     * <param name="context">The authorization filter context</param>
     */
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();

        if (allowAnonymous)
        {
            Console.WriteLine(" Skipping authorization");
            return;
        }

        // verify if user is logged in by checking if HttpContext.User is set
        var user = (User?)context.HttpContext.Items["User"];

        // if user is not logged in then return 401 status code
        if (user == null) context.Result = new UnauthorizedResult();
    }
}