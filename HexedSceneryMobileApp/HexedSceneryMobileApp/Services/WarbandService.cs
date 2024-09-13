using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Services
{
    public interface IWarbandService
    {
        Task<List<Models.Warband>> GetWarbandsAsync();
    }

    public class WarbandService : IWarbandService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        private static List<Models.Warband> _warbandCache = new List<Models.Warband>();

        public WarbandService(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<List<Models.Warband>> GetWarbandsAsync()
        {
            var url = "warband";

            if (!_warbandCache.Any())
            {
                try
                {
                    using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                    {
                        var data = await httpClient.GetFromJsonAsync<IEnumerable<ApiModels.Warband>>(url);
                        var warbands = _mapper.Map<IEnumerable<Models.Warband>>(data);
                        _warbandCache.AddRange(warbands);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return _warbandCache;
        }
    }
}
