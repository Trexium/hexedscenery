using HexedSceneryData.Data;
using HexedSceneryData.Models;
using HexedSceneryWebsite.Api.Auth;
using HexedSceneryWebsite.Api.v1.Models.Menu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HexedSceneryWebsite.Api.v1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly HexedSceneryContext _context;
        private static readonly string[] _skipNames = new[] { "Crit_", "Sawbones_" };

        public MenuController(HexedSceneryContext context)
        {
            _context = context;
        }

        // GET: api/<MenuController>
        [HttpGet]
        [ApiKey]
        public Menu Get()
        {
            var menu = new Menu();
            
            var categories = _context.TableCategories.Include(m => m.EncounterTypes).Where(m => m.Active == true);

            menu.Items = new List<MenuItem>();
            menu.Groups = new List<MenuGroup>();

            // Preperation
            var prepGroup = new MenuGroup();
            prepGroup.Id = "preperation";
            prepGroup.DisplayText = "Preperation";
            prepGroup.Items = new List<MenuItem>();
            prepGroup.Items.Add(new MenuItem { DisplayText = "Hired Swords", Name = "HiredSwords", Url = "hiredswords" });
            menu.Groups.Add(prepGroup);

            // Encounters
            var encounterCategory = categories.First(m => m.Id == 3);
            var encounterGroup = GenerateTopLevelGroupByCategory(encounterCategory);
            menu.Groups.Add(encounterGroup);

            // Skirmish
            var skirmishCategory = categories.First(m => m.Id == 4);
            var skirmishGroup = GenerateTopLevelGroupByCategory(skirmishCategory);
            skirmishGroup.Groups = new List<MenuGroup>();
            skirmishGroup.Groups.Add(GenerateSubGroupByPrefix(skirmishCategory, "Crit_", "Critical Hits"));
            menu.Groups.Add(skirmishGroup);

            // Post-Battle Sequence
            var pbsCategory = categories.First(m => m.Id == 5);
            var pbsGroup = GenerateTopLevelGroupByCategory(pbsCategory);
            pbsGroup.Groups = new List<MenuGroup>();
            pbsGroup.Groups.Add(GenerateSubGroupByPrefix(pbsCategory, "Sawbones_", "Sawbones"));
            menu.Groups.Add(pbsGroup);


            return menu;
        }

        private bool IsInSkipList(string name)
        {
            foreach(var skipString in _skipNames)
            {
                if (name.StartsWith(skipString))
                {
                    return true;
                }
            }

            return false;
        }

        private MenuGroup GenerateTopLevelGroupByCategory(TableCategory category)
        {
            var group = new MenuGroup();
            group.Id = $"category_{category.Id}";
            group.DisplayText = category.DisplayName;
            group.Items = new List<MenuItem>();

            foreach (var encounterType in category.EncounterTypes)
            {
                if (!IsInSkipList(encounterType.Name))
                {
                    var menuItem = new MenuItem();
                    menuItem.Id = encounterType.Id;
                    menuItem.Name = encounterType.Name;
                    menuItem.DisplayText = encounterType.DisplayName;
                    menuItem.Url = $"encountertype/{encounterType.Id}";
                    menuItem.Type = MenuItemTypeEnum.EncounterType;
                    group.Items.Add(menuItem);
                }
            }

            return group;
        }

        private MenuGroup GenerateSubGroupByPrefix(TableCategory category, string prefix, string title)
        {
            var group = new MenuGroup();
            group.Id = prefix;
            group.DisplayText = title;
            group.Items = new List<MenuItem>();
            
            foreach (var encounterType in category.EncounterTypes.Where(m => m.Name.StartsWith(prefix)))
            {
                var menuItem = new MenuItem();
                menuItem.Id = encounterType.Id;
                menuItem.Name = encounterType.Name;
                menuItem.DisplayText = encounterType.DisplayName;
                menuItem.Url = $"encountertype/{encounterType.Id}";
                menuItem.Type = MenuItemTypeEnum.EncounterType;
                group.Items.Add(menuItem);
            }

            return group;
        }
    }
}
