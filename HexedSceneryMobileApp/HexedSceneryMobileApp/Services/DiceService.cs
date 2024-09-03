
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace HexedSceneryMobileApp.Services
{
    public interface IDiceService
    {
        Task<Models.DiceType> GetDiceTypeAsync(int diceTypeId);
    }
    public class DiceService : IDiceService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private static Dictionary<int, Models.DiceType> _diceTypeCache = new Dictionary<int, Models.DiceType>();

        public DiceService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Models.DiceType> GetDiceTypeAsync(int diceTypeId)
        {
            var url = $"dice/{diceTypeId}";

            if (!_diceTypeCache.ContainsKey(diceTypeId))
            {
                using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                {
                    var diceType = await httpClient.GetFromJsonAsync<ApiModels.DiceType>(url);
                    _diceTypeCache.Add(diceTypeId, diceType);
                }
            }

            return _diceTypeCache[diceTypeId];
        }
    }
}
