
using HexedSceneryApiClient.Models;
using HexedSceneryApiClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp
{
    public class DummyData : IEncounterService, IHiredSwordService
    {
        //public List<EncounterType> GetEncounterTypes()
        //{
        //    var testdata = new List<EncounterType>();
        //    testdata.Add(new EncounterType
        //    {
        //        Id = 1,
        //        Name = "Random Happenings",
        //        DiceType = HexedSceneryCommon.Enums.DiceType.D66,
        //        NumberOfDice = 1
        //    });
        //    testdata.Add(new EncounterType
        //    {
        //        Id = 2,
        //        Name = "Subplots",
        //        DiceType = HexedSceneryCommon.Enums.DiceType.D6,
        //        NumberOfDice = 3
        //    });
        //    testdata.Add(new EncounterType
        //    {
        //        Id = 3,
        //        Name = "Town Cryer",
        //        DiceType = HexedSceneryCommon.Enums.DiceType.D6,
        //        NumberOfDice = 2
        //    });
        //    testdata.Add(new EncounterType
        //    {
        //        Id = 4,
        //        Name = "Treasures of the Underground",
        //        DiceType = HexedSceneryCommon.Enums.DiceType.D6,
        //        NumberOfDice = 1
        //    });

        //    return testdata;
        //}

        //public List<GamePlayTableType> GetGamePlayTableTypes()
        //{
        //    var testdata = new List<GamePlayTableType>();
        //    testdata.Add(new GamePlayTableType
        //    {
        //        Id = 1,
        //        Name = "Animosity",
        //        DiceType = HexedSceneryCommon.Enums.DiceType.D6,
        //        NumberOfDice = 1
        //    });
        //    testdata.Add(new GamePlayTableType
        //    {
        //        Id = 2,
        //        Name = "Blackpowder Misfires",
        //        DiceType = HexedSceneryCommon.Enums.DiceType.D6,
        //        NumberOfDice = 1
        //    });
        //    testdata.Add(new GamePlayTableType
        //    {
        //        Id = 3,
        //        Name = "Critical Hits",
        //        DiceType = HexedSceneryCommon.Enums.DiceType.D6,
        //        NumberOfDice = 1
        //    });
        //    testdata.Add(new GamePlayTableType
        //    {
        //        Id = 4,
        //        Name = "Stupidity",
        //        DiceType = HexedSceneryCommon.Enums.DiceType.D6,
        //        NumberOfDice = 1
        //    });
        //    return testdata;
        //}

        //public List<PostGameTableType> GetPostGameTableTypes()
        //{
        //    var testdata = new List<PostGameTableType>();
        //    testdata.Add(new PostGameTableType
        //    {
        //        Id = 1,
        //        Name = "Power in the Stones",
        //        DiceType = HexedSceneryCommon.Enums.DiceType.D6,
        //        NumberOfDice = 2
        //    });
        //    testdata.Add(new PostGameTableType
        //    {
        //        Id = 2,
        //        Name = "Rewards of the Shadowlord",
        //        DiceType = HexedSceneryCommon.Enums.DiceType.D6,
        //        NumberOfDice = 2
        //    });
        //    testdata.Add(new PostGameTableType
        //    {
        //        Id = 3,
        //        Name = "Random Mutations",
        //        DiceType = HexedSceneryCommon.Enums.DiceType.D66,
        //        NumberOfDice = 1
        //    });
        //    testdata.Add(new PostGameTableType
        //    {
        //        Id = 4,
        //        Name = "Sawbones",
        //        DiceType = HexedSceneryCommon.Enums.DiceType.D6,
        //        NumberOfDice = 2
        //    });
        //    testdata.Add(new PostGameTableType
        //    {
        //        Id = 5,
        //        Name = "Serious Injuries",
        //        DiceType = HexedSceneryCommon.Enums.DiceType.D66,
        //        NumberOfDice = 1
        //    });
        //    testdata.Add(new PostGameTableType
        //    {
        //        Id = 6,
        //        Name = "Rabble Rousing",
        //        DiceType = HexedSceneryCommon.Enums.DiceType.D6,
        //        NumberOfDice = 2
        //    });

        //    return testdata;
        //}
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
