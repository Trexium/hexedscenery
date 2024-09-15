
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace HexedSceneryMobileApp.Services
{
    public interface IDiceService
    {
        Task<Models.DiceType> GetDiceTypeAsync(int diceTypeId);
        Task<List<Models.DiceType>> GetDiceTypesAsync();
    }
    public class DiceService : IDiceService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private static Dictionary<int, Models.DiceType> _diceTypeCache = new Dictionary<int, Models.DiceType>();

        public DiceService(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<Models.DiceType> GetDiceTypeAsync(int diceTypeId)
        {
            var url = $"dice/{diceTypeId}";

            if (!_diceTypeCache.ContainsKey(diceTypeId))
            {
                try
                {
                    using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                    {
                        var data = await httpClient.GetFromJsonAsync<ApiModels.DiceType>(url);
                        var diceType = _mapper.Map<Models.DiceType>(data);
                        _diceTypeCache.Add(diceTypeId, diceType);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return _diceTypeCache[diceTypeId];
        }

        public async Task<List<Models.DiceType>> GetDiceTypesAsync()
        {
            var url = $"dice";

            if (_diceTypeCache.Count == 0)
            {
                try
                {
                    using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                    {
                        var data = await httpClient.GetFromJsonAsync<List<ApiModels.DiceType>>(url);
                        var diceTypes = _mapper.Map<List<Models.DiceType>>(data);

                        foreach(var diceType in diceTypes)
                        {
                            _diceTypeCache.Add(diceType.Id, diceType);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return _diceTypeCache.Values.ToList();
        }
    }
}
