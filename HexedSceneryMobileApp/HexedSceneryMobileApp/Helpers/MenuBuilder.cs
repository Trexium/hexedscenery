﻿using HexedSceneryData.Services;
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
        Task<List<MenuTitle>> GetMenuAsync();
    }
    public class MenuBuilder : IMenuBuilder
    {
        private readonly IEncounterService _encounterService;
        private readonly IHiredSwordService _hiredSwordService;
        private readonly List<MenuTitle> _menu;

        public MenuBuilder(IEncounterService encounterService, IHiredSwordService hiredSwordService)
        {
            _encounterService = encounterService;
            _hiredSwordService = hiredSwordService;
            _menu = new List<MenuTitle>();
        }

        public async Task<List<MenuTitle>> GetMenuAsync()
        {
            if (!_menu.Any())
            {
                var categories = await _encounterService.GetTableCategoriesAsync();

                foreach (var category in categories)
                {
                    var menuTitle = new MenuTitle
                    {
                        DisplayTitle = category.DisplayName,
                        Children = new List<Models.MenuItem>()
                    };

                    foreach(var encounterType in category.EncounterTypes)
                    {
                        menuTitle.Children.Add(new Models.MenuItem
                        {
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