

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
        Task<Models.Encounter> GetEncounterAsync(int encounterTypeId, int resultNumber);
    }
    public class EncounterService : IEncounterService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private readonly IDiceService _diceService;
        private static readonly Dictionary<string, List<Models.TableCategory>> _categoryCache = new Dictionary<string, List<Models.TableCategory>>();
        private static readonly Dictionary<int, Models.EncounterType> _encounterTypeCache = new Dictionary<int, Models.EncounterType>();
        private static readonly Dictionary<string, Models.Encounter> _encounterCache = new Dictionary<string, Models.Encounter>();

        public EncounterService(IHttpClientFactory httpClientFactory, IMapper mapper, IDiceService diceService)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
            _diceService = diceService;
        }

        public async Task<List<Models.TableCategory>> GetTableCategoriesAsync()
        {
            var url = "category/includeChildren";

            if (!_categoryCache.ContainsKey(url))
            {
                try
                {
                    using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                    {
                        var data = await httpClient.GetFromJsonAsync<IEnumerable<ApiModels.TableCategory>>(url);
                        var categories = _mapper.Map<IEnumerable<Models.TableCategory>>(data);
                        _categoryCache.Add(url, categories.ToList());
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return _categoryCache[url];
        }

        public async Task<Models.EncounterType> GetEncounterTypeAsync(int id)
        {
            var url = $"encountertype/{id}";

            if (!_encounterTypeCache.ContainsKey(id))
            {
                try
                {
                    using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                    {

                        var data = await httpClient.GetFromJsonAsync<ApiModels.EncounterType>(url);
                        var encounterType = _mapper.Map<Models.EncounterType>(data);
                        _encounterTypeCache.Add(id, encounterType);

                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return _encounterTypeCache[id];
        }

        public async Task<Models.Encounter> GetEncounterAsync(int encounterTypeId, int resultNumber)
        {
            var url = $"encounter/{encounterTypeId}/{resultNumber}";

            if (!_encounterCache.ContainsKey(url))
            {
                try
                {
                    using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                    {
                        var data = await httpClient.GetFromJsonAsync<ApiModels.Encounter>(url);
                        var encounter = _mapper.Map<Models.Encounter>(data);
                        _encounterCache.Add(url, encounter);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return _encounterCache[url];
        }
    }
}
