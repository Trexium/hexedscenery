namespace HexedSceneryWebsite.Api.Auth
{
    public interface IApiKeyValidator
    {
        bool Validate(string apiKey);
    }
    public class ApiKeyValidator : IApiKeyValidator
    {
        private readonly string[] _apiKeys;

        public ApiKeyValidator(string[] apiKeys)
        {
            _apiKeys = apiKeys;
        }

        public bool Validate(string apiKey)
        {
            if (_apiKeys != null && _apiKeys.Any())
            {
                if (!string.IsNullOrEmpty(apiKey))
                {
                    if (_apiKeys.Contains(apiKey))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
