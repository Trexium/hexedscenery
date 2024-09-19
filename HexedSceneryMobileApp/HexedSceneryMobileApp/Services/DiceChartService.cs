using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Services
{
    public interface IDiceChartService
    {
        Task LoadCachesAsync();
        Task<Models.DiceChart> GetDiceChartAsync(int diceChartId);
    }
    public class DiceChartService : IDiceChartService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private static Dictionary<int, Models.DiceChart> _diceChartCache = new Dictionary<int, Models.DiceChart>();

        public DiceChartService(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<Models.DiceChart> GetDiceChartAsync(int diceChartId)
        {
            if (!_diceChartCache.ContainsKey(diceChartId))
            {
                await LoadCachesAsync();
            }

            return _diceChartCache[diceChartId];
        }

        public async Task LoadCachesAsync()
        {
            var url = $"dicechart";

            if (_diceChartCache.Count  < 1)
            {
                try
                {
                    using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                    {
                        var data = await httpClient.GetFromJsonAsync<List<ApiModels.DiceChart>>(url);
                        var diceCharts = _mapper.Map<List<Models.DiceChart>>(data);
                        foreach (var diceChart in diceCharts)
                        {
                            _diceChartCache.Add(diceChart.Id, diceChart);
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
