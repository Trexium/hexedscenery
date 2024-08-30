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
        Task<List<MenuGroup>> GetMenuAsync();
    }
    public class MenuBuilder : IMenuBuilder
    {
        private readonly IEncounterService _encounterService;
        private readonly IHiredSwordService _hiredSwordService;
        private readonly List<MenuGroup> _menu;

        public MenuBuilder(IEncounterService encounterService, IHiredSwordService hiredSwordService)
        {
            _encounterService = encounterService;
            _hiredSwordService = hiredSwordService;
            _menu = new List<MenuGroup>();
        }

        public async Task<List<MenuGroup>> GetMenuAsync()
        {
            if (!_menu.Any())
            {
                var categories = await _encounterService.GetTableCategoriesAsync();

                foreach (var category in categories)
                {
                    var menuTitle = new MenuGroup
                    {
                        Id = $"category_{category.Id}",
                        DisplayTitle = category.DisplayName,
                        Expanded = false,
                        Children = new List<Models.MenuItem>()
                    };

                    foreach(var encounterType in category.EncounterTypes)
                    {
                        menuTitle.Children.Add(new Models.MenuItem
                        {
                            Id = $"encounterType_{encounterType.Id}",
                            DisplayName = encounterType.DisplayName,
                            Url = ""
                        });
                    }

                    _menu.Add(menuTitle);
                }
            }

            return _menu;
        }
    }
}
