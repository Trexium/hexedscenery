using Microsoft.AspNetCore.Mvc;

namespace HexedSceneryWebsite.Api.Auth
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute()
        : base(typeof(ApiKeyAuthorizationFilter))
        {
        }
    }
}
