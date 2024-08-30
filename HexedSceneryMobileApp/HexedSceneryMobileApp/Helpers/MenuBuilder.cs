using HexedSceneryApiClient.Services;
using HexedSceneryMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Helpers
{
    public interface IMenuBuilder
    {
        Task<Menu> GetMenuAsync();
    }
    public class MenuBuilder : IMenuBuilder
    {
        private readonly IMenuService _menuService;
        private static Menu _menu;

        public MenuBuilder(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task<Menu> GetMenuAsync()
        {
            if (_menu == null)
            {
                var menu = await _menuService.GetMenuAsync();

                _menu = menu.ToViewModel();
            }

            return _menu;
        }
    }
}
