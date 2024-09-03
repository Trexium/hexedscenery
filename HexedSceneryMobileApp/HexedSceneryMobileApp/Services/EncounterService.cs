

using HexedSceneryApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Services
{
    public interface IEncounterService
    {
        Task<List<TableCategory>> GetTableCategoriesAsync();
        Task<EncounterType> GetEncounterTypeAsync(int id);
    }
    public class EncounterService : IEncounterService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private static readonly Dictionary<string, List<TableCategory>> _categoryCache = new Dictionary<string, List<TableCategory>>();
        private static readonly Dictionary<int, EncounterType> _encounterTypeCache = new Dictionary<int, EncounterType>();

        public EncounterService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<TableCategory>> GetTableCategoriesAsync()
        {
            var url = "category/includeChildren";

            if (!_categoryCache.ContainsKey(url))
            {
                using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                {
                    var categories = await httpClient.GetFromJsonAsync<IEnumerable<TableCategory>>(url);
                    _categoryCache.Add(url, categories.ToList());
                }
            }
            
            return _categoryCache[url];
        }

        public async Task<EncounterType> GetEncounterTypeAsync(int id)
        {
            var url = $"encountertype/{id}";

            if (!_encounterTypeCache.ContainsKey(id))
            {
                using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                {
                    var encounterType = await httpClient.GetFromJsonAsync<EncounterType>(url);
                    _encounterTypeCache.Add(id, encounterType);
                }
            }

            return _encounterTypeCache[id];
        }
    }
}
