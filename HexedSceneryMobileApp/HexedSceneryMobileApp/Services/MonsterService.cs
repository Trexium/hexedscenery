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
        Task<List<Models.Monster>> GetMonstersAsync();
    }

    public class MonsterService : IMonsterService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private readonly ILogService _logger;

        private static Dictionary<int, Monster> _monsterCache = new Dictionary<int, Monster>();

        public MonsterService(IHttpClientFactory httpClientFactory, IMapper mapper, ILogService logger)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
            _logger = logger;
        }



        public async Task<Monster> GetMonsterAsync(int monsterId)
        {
            var url = $"monster/{monsterId}";

            if (!_monsterCache.ContainsKey(monsterId))
            {
                await GetMonstersAsync();
            }

            return _monsterCache[monsterId];
        }

        public async Task<List<Monster>> GetMonstersAsync()
        {
            var url = $"monster";

            if (_monsterCache.Count > 1)
            {
                try
                {
                    using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                    {
                        var data = await httpClient.GetFromJsonAsync<List<ApiModels.Monster>>(url);
                        var monsters = _mapper.Map<List<Models.Monster>>(data);
                        foreach(var monster in monsters)
                        {
                            _monsterCache.Add(monster.Id, monster);
                        }
                    }
                }
                catch (Exception ex)
                {
                    await _logger.ErrorAsync("Network problem", ex);
                    return null;
                }
            }

            return _monsterCache.Values.ToList();
        }
    }
}
