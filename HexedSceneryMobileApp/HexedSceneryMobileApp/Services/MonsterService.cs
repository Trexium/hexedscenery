using AutoMapper;
using HexedSceneryMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Services
{
    public interface IMonsterService
    {
        Task<Models.Monster> GetMonsterAsync(int monsterId);
    }

    public class MonsterService : IMonsterService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private readonly ILogService _logger;

        private static Dictionary<string, Monster> _monsterCache = new Dictionary<string, Monster>();

        public MonsterService(IHttpClientFactory httpClientFactory, IMapper mapper, ILogService logger)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Monster> GetMonsterAsync(int monsterId)
        {
            var url = $"monster/{monsterId}";

            if (!_monsterCache.ContainsKey(url))
            {
                try
                {
                    using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                    {
                        var data = await httpClient.GetFromJsonAsync<ApiModels.Monster>(url);
                        var encounter = _mapper.Map<Models.Monster>(data);
                        _monsterCache.Add(url, encounter);
                    }
                }
                catch (Exception ex)
                {
                    await _logger.ErrorAsync("Network problem", ex);
                    return null;
                }
            }

            return _monsterCache[url];
        }
    }
}
