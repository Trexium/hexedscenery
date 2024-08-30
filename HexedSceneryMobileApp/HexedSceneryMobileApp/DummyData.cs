
using HexedSceneryApiClient.Models;
using HexedSceneryApiClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp
{
    public class DummyData : IEncounterService, IHiredSwordService, IMenuService
    {
        private readonly string _dummyMenuJson = @"{""Title"":null,""Items"":[],""Groups"":[{""Id"":""preperation"",""DisplayText"":""Preperation"",""Items"":[{""Id"":""hiredswords"",""DisplayText"":""Hired Swords"",""Name"":""HiredSwords""}],""Groups"":null},{""Id"":""category_3"",""DisplayText"":""Encounters"",""Items"":[{""Id"":""encounterType_1"",""DisplayText"":""Random Happenings"",""Name"":""RandomHappening""},{""Id"":""encounterType_2"",""DisplayText"":""Subplots"",""Name"":""SubPlot""},{""Id"":""encounterType_15"",""DisplayText"":""The Town Cryer in Mordheim"",""Name"":""TheTownCryerInMordheim""},{""Id"":""encounterType_21"",""DisplayText"":""Treasures of the Underground"",""Name"":""TreasuresOfTheUnderground""}],""Groups"":null},{""Id"":""category_4"",""DisplayText"":""Skirmish"",""Items"":[{""Id"":""encounterType_6"",""DisplayText"":""Black Powder Misfires"",""Name"":""Misfires""},{""Id"":""encounterType_13"",""DisplayText"":""Stupidity"",""Name"":""Stupidity""},{""Id"":""encounterType_14"",""DisplayText"":""Animosity"",""Name"":""Animosity""}],""Groups"":[{""Id"":""Crit_"",""DisplayText"":""Critical Hits"",""Items"":[{""Id"":""encounterType_8"",""DisplayText"":""Missile Weapons"",""Name"":""Crit_MissileWeapons""},{""Id"":""encounterType_9"",""DisplayText"":""Bludgeon Weapons"",""Name"":""Crit_BludgeonWeapons""},{""Id"":""encounterType_10"",""DisplayText"":""Bladed Weapons"",""Name"":""Crit_BladedWeapons""},{""Id"":""encounterType_11"",""DisplayText"":""Unarmed"",""Name"":""Crit_UnarmedCombat""},{""Id"":""encounterType_12"",""DisplayText"":""Thrusting Weapons"",""Name"":""Crit_ThrustingWeapons""},{""Id"":""encounterType_19"",""DisplayText"":""Flexible Weapons"",""Name"":""Crit_FlexibleWeapons""}],""Groups"":null}]},{""Id"":""category_5"",""DisplayText"":""Post-Battle Sequence"",""Items"":[{""Id"":""encounterType_3"",""DisplayText"":""Power in the Stones"",""Name"":""PowerInTheStones""},{""Id"":""encounterType_4"",""DisplayText"":""Using Stones"",""Name"":""UsingStones""},{""Id"":""encounterType_5"",""DisplayText"":""Random Mutations"",""Name"":""RandomMutationTable""},{""Id"":""encounterType_7"",""DisplayText"":""Rewards of the Shadowlord"",""Name"":""RewardsOfTheShadowlord""},{""Id"":""encounterType_18"",""DisplayText"":""Witch Hunter Rabble Rousing"",""Name"":""RabbleRousing""},{""Id"":""encounterType_20"",""DisplayText"":""Serious Injuries"",""Name"":""SeriousInjuries""}],""Groups"":[{""Id"":""Sawbones_"",""DisplayText"":""Sawbones"",""Items"":[{""Id"":""encounterType_16"",""DisplayText"":""Limb Surgery"",""Name"":""Sawbones_LimbSurgery""},{""Id"":""encounterType_17"",""DisplayText"":""Brain Surgery"",""Name"":""Sawbones_BrainSurgery""}],""Groups"":null}]}]}";


        public async Task<Menu> GetMenuAsync()
        {
            var menu = System.Text.Json.JsonSerializer.Deserialize<Menu>(_dummyMenuJson);
            return menu;
        }

        public async Task<List<TableCategory>> GetTableCategoriesAsync()
        {
            var testdata = new List<TableCategory>();
            testdata.Add(new TableCategory
            {
                Id = 1,
                DisplayName = null,
                Active = true,
                EncounterTypes = new List<EncounterType>()
            });
            testdata.Add(new TableCategory
            {
                Id = 2,
                DisplayName = "Encounters",
                Active = true,
                EncounterTypes = new List<EncounterType>
                {
                    new EncounterType { Id = 1, DisplayName = "Random Happenings", Name = "RandomHappening"},
                    new EncounterType { Id = 2, DisplayName = "Subplots", Name = "Subplots"},
                    new EncounterType { Id = 3, DisplayName = "The Town Cryer in Mordheim", Name = "TheTownCryerInMordheim" },
                    new EncounterType { Id = 4, DisplayName = "Treasures of the Underground", Name = "TreasuresOfTheUnderground" }
                }
            });

            testdata.Add(new TableCategory
            {
                Id = 3,
                DisplayName = "Skirmish",
                Active = true,
                EncounterTypes = new List<EncounterType>
                {
                    new EncounterType { Id = 5, DisplayName = "Black Powder Misfires", Name = "Misfires"},
                    new EncounterType { Id = 6, DisplayName = "Missile Weapons", Name = "Crit_MissileWeapons" },
                    new EncounterType { Id = 7, DisplayName = "Bludgeon Weapons", Name = "Crit_BludgeonWeapons" },
                    new EncounterType { Id = 8, DisplayName = "Bladed Weapons", Name = "Crit_BladedWeapons" },
                    new EncounterType { Id = 9, DisplayName = "Unarmed", Name = "Crit_UnarmedCombat"},
                    new EncounterType { Id = 10, DisplayName = "Thrusting Weapons", Name = "Crit_ThrustingWeapons"},
                    new EncounterType { Id = 11, DisplayName = "Flexible Weapons", Name = "Crit_FlexibleWeapons"},
                    new EncounterType { Id = 12, DisplayName = "Stupidity", Name = "Stupidity"},
                    new EncounterType { Id = 13, DisplayName = "Animosity", Name = "Animosity"}
                }
            });

            testdata.Add(new TableCategory
            {
                Id = 4,
                DisplayName = "Post-Battle Sequence",
                Active = true,
                EncounterTypes = new List<EncounterType>
                {
                    new EncounterType { Id = 14, DisplayName = "Power in the Stones", Name = "PowerInTheStones"},
                    new EncounterType { Id = 15, DisplayName = "Random Mutations", Name = "RandomMutationTable"},
                    new EncounterType { Id = 16, DisplayName = "Rewards of the Shadowlord", Name = "RewardsOfTheShadowlord" },
                    new EncounterType { Id = 17, DisplayName = "Limb Surgery", Name = "Sawbones_LimbSurgery" },
                    new EncounterType { Id = 18, DisplayName = "Brain Surgery", Name = "Sawbones_BrainSurgery" },
                    new EncounterType { Id = 19, DisplayName = "Witch Hunter Rabble Rousing", Name = "RabbleRousing" },
                    new EncounterType { Id = 20, DisplayName = "Serious Injuries", Name = "SeriousInjuries" }
                }
            });

            return testdata;
        }
    }
}
