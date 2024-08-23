using HexedSceneryData.Services;
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
        List<MenuTitle> GetMenu();
    }
    public class MenuBuilder : IMenuBuilder
    {
        private readonly IEncounterService _encounterService;
        private readonly IGamePlayService _gamePlayService;
        private readonly IPostGameService _postGameService;
        private readonly IHiredSwordService _hiredSwordService;
        private readonly List<MenuTitle> _menu;

        public MenuBuilder(IEncounterService encounterService, IGamePlayService gamePlayService, IPostGameService postGameService, IHiredSwordService hiredSwordService)
        {
            _encounterService = encounterService;
            _gamePlayService = gamePlayService;
            _postGameService = postGameService;
            _hiredSwordService = hiredSwordService;
            _menu = new List<MenuTitle>();
        }

        public List<MenuTitle> GetMenu()
        {
            if (!_menu.Any())
            {
                var encounterTypes = _encounterService.GetEncounterTypes();
                var gamePlayTableTypes = _gamePlayService.GetGamePlayTableTypes();
                var postGameTableTypes = _postGameService.GetPostGameTableTypes();

                if (gamePlayTableTypes != null && gamePlayTableTypes.Any())
                {
                    AddTableTypesToMenu(gamePlayTableTypes, "Skirmish", "someComponent");
                }

                if (encounterTypes != null && encounterTypes.Any())
                {
                    AddTableTypesToMenu(encounterTypes, "Encounters", "encounter");
                }

                if (postGameTableTypes != null && postGameTableTypes.Any())
                {
                    AddTableTypesToMenu(postGameTableTypes, "Post-Battle Sequence", "someComponent");
                }
            }

            return _menu;
        }

        private void AddTableTypesToMenu<T>(List<T> tableTypeModels, string title, string componentName) where T : HexedSceneryCommon.Models.TableTypeModel
        {
            var menuTitle = new MenuTitle
            {
                DisplayTitle = title,
                Children = new List<Models.MenuItem>()
            };
            foreach (var tableType in tableTypeModels)
            {
                var menuItem = new Models.MenuItem();
                menuItem.DisplayName = tableType.Name;

                if (tableType.Children == null || !tableType.Children.Any())
                {
                    menuItem.Url = componentName;
                }
                else
                {
                    menuItem.Children = new List<Models.MenuItem>();
                    foreach (var child in tableType.Children)
                    {
                        menuItem.Children.Add(new Models.MenuItem()
                        {
                            DisplayName = child.Name,
                            Url = componentName
                        });
                    }
                }
                menuTitle.Children.Add(menuItem);
            }

            _menu.Add(menuTitle);
        }
    }
}
