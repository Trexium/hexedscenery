

using HexedSceneryApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryApiClient.Services
{
    public interface IEncounterService
    {
        Task<List<TableCategory>> GetTableCategoriesAsync();
    }
    public class EncounterService : IEncounterService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private static readonly Dictionary<string, object> _cache = new Dictionary<string, object>();

        public EncounterService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<TableCategory>> GetTableCategoriesAsync()
        {
            var url = "category/includeChildren";

            if (!_cache.ContainsKey(url))
            {
                using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                {

                    var json = await httpClient.GetStringAsync(url);
                    Console.WriteLine(json);
                    var categories = await httpClient.GetFromJsonAsync<IEnumerable<TableCategory>>(url);
                    _cache.Add(url, categories.ToList());
                }
            }
            
            return (List<TableCategory>)_cache[url];
        }
    }
}
