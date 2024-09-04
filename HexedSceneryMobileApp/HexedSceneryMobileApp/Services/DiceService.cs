
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
                using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                {
                    var data = await httpClient.GetFromJsonAsync<ApiModels.DiceType>(url);
                    var diceType = _mapper.Map<Models.DiceType>(data);
                    _diceTypeCache.Add(diceTypeId, diceType);
                }
            }

            return _diceTypeCache[diceTypeId];
        }
    }
}
