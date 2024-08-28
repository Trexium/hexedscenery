using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualBasic;

namespace HexedSceneryWebsite.Api.Auth
{
    public class ApiKeyAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var apiKeyValidator = context.HttpContext.RequestServices.GetService<IApiKeyValidator>();
            string userApiKey = context.HttpContext.Request.Headers["ApiKey"].ToString();

            if (apiKeyValidator == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!apiKeyValidator.Validate(userApiKey))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
