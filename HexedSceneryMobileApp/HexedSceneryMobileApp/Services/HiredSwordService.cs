using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Services
{
    public interface IHiredSwordService
    {
        Task<List<Models.HiredSword>> GetHiredSwordsAsync();
    }
    public class HiredSwordService : IHiredSwordService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        
        private static List<Models.HiredSword> _hiredSwordCache = new List<Models.HiredSword>();

        public HiredSwordService(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<List<Models.HiredSword>> GetHiredSwordsAsync()
        {
            var url = "hiredsword";

            if (!_hiredSwordCache.Any())
            {
                try
                {
                    using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                    {
                        var data = await httpClient.GetFromJsonAsync<IEnumerable<ApiModels.HiredSword>>(url);
                        var hiredSwords = _mapper.Map<IEnumerable<Models.HiredSword>>(data);
                        _hiredSwordCache.AddRange(hiredSwords);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return _hiredSwordCache;
        }
    }
}
