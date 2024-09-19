

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
        Task LoadCachesAsync();
    }
    public class EncounterService : IEncounterService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private readonly IDiceService _diceService;
        private static readonly Dictionary<string, List<Models.TableCategory>> _categoryCache = new Dictionary<string, List<Models.TableCategory>>();
        private static readonly Dictionary<int, Models.EncounterType> _encounterTypeCache = new Dictionary<int, Models.EncounterType>();
        private static readonly Dictionary<int, Dictionary<int, Models.Encounter>> _encounterCache = new Dictionary<int, Dictionary<int, Models.Encounter>>();

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
            //var url = $"encountertype/{id}";

            if (!_encounterTypeCache.ContainsKey(id))
            {
                await LoadCachesAsync();
            }

            return _encounterTypeCache[id];
        }

        public async Task<Models.Encounter> GetEncounterAsync(int encounterTypeId, int resultNumber)
        {
            //var url = $"encounter/{encounterTypeId}/{resultNumber}";

            if (!_encounterCache.ContainsKey(encounterTypeId))
            {
                await LoadCachesAsync();
            }

            return (_encounterCache[encounterTypeId])[resultNumber];
        }

        public async Task LoadCachesAsync()
        {
            

            if (_encounterCache.Count < 1)
            {
                try
                {
                    using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                    {
                        var url = $"encounter";
                        var data = await httpClient.GetFromJsonAsync<List<ApiModels.Encounter>>(url);
                        var encounters = _mapper.Map<List<Models.Encounter>>(data);

                        foreach (var encounter in encounters)
                        {
                            if (_encounterCache.ContainsKey(encounter.EncounterTypeId))
                            {
                                _encounterCache[encounter.EncounterTypeId].Add(encounter.ResultNumber, encounter);
                            }
                            else
                            {
                                var encounterDict = new Dictionary<int, Models.Encounter>();
                                encounterDict.Add(encounter.ResultNumber, encounter);
                                _encounterCache.Add(encounter.EncounterTypeId, encounterDict);
                            }
                        }
                    }

                    using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                    {
                        var url = "encountertype";
                        var data = await httpClient.GetFromJsonAsync<List<ApiModels.EncounterType>>(url);
                        var encounterTypes = _mapper.Map<List<Models.EncounterType>>(data);

                        foreach (var encounterType in encounterTypes)
                        {
                            _encounterTypeCache.Add(encounterType.Id, encounterType);
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
        }
    }
}
