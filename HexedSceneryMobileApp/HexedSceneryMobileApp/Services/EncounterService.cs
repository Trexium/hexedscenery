

using AutoMapper;
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
        Task<List<Models.TableCategory>> GetTableCategoriesAsync();
        Task<Models.EncounterType> GetEncounterTypeAsync(int id);
    }
    public class EncounterService : IEncounterService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private static readonly Dictionary<string, List<Models.TableCategory>> _categoryCache = new Dictionary<string, List<Models.TableCategory>>();
        private static readonly Dictionary<int, Models.EncounterType> _encounterTypeCache = new Dictionary<int, Models.EncounterType>();

        public EncounterService(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<List<Models.TableCategory>> GetTableCategoriesAsync()
        {
            var url = "category/includeChildren";

            if (!_categoryCache.ContainsKey(url))
            {
                using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                {
                    var data = await httpClient.GetFromJsonAsync<IEnumerable<ApiModels.TableCategory>>(url);
                    var categories = _mapper.Map<IEnumerable<Models.TableCategory>>(data);
                    _categoryCache.Add(url, categories.ToList());
                }
            }
            
            return _categoryCache[url];
        }

        public async Task<Models.EncounterType> GetEncounterTypeAsync(int id)
        {
            var url = $"encountertype/{id}";

            if (!_encounterTypeCache.ContainsKey(id))
            {
                using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                {
                    var data = await httpClient.GetFromJsonAsync<ApiModels.EncounterType>(url);
                    var encounterType = _mapper.Map<Models.EncounterType>(data);
                    _encounterTypeCache.Add(id, encounterType);
                }
            }

            return _encounterTypeCache[id];
        }
    }
}
