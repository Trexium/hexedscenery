using HexedSceneryApiClient.Models;
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
        Task<Menu> GetMenuAsync();
    }

    public class MenuService : IMenuService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private static Menu _menuCache; 

        public MenuService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Menu> GetMenuAsync()
        {
            var url = "menu";

            if (_menuCache == null)
            {
                using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                {
                    var menu = await httpClient.GetFromJsonAsync<Menu>(url);
                    _menuCache = menu;
                }
            }

            return _menuCache;
        }
    }
}
