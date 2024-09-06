
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Services
{
    public interface IMenuService
    {
        Task<Models.Menu> GetMenuAsync();
    }

    public class MenuService : IMenuService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        private static Models.Menu _menuCache; 

        public MenuService(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<Models.Menu> GetMenuAsync()
        {
            var url = "menu";

            if (_menuCache == null)
            {
                try
                {
                    using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                    {
                        var data = await httpClient.GetFromJsonAsync<ApiModels.Menu>(url);
                        var menu = _mapper.Map<Models.Menu>(data);
                        _menuCache = menu;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return _menuCache;
        }
    }
}
