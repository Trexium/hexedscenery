
using HexedSceneryMobileApp.Models;
using HexedSceneryMobileApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp
{
    public class DummyData : IEncounterService, IHiredSwordService, IMenuService, IDiceService, IDiceChartService, IGradeService, IMonsterService, IWarbandService
    {
        private readonly string _dummyMenuJson = @"{
    ""Title"": null,
    ""Items"": [],
    ""Groups"": [
        {
            ""Id"": ""preperation"",
            ""DisplayText"": ""Preperation"",
            ""Expanded"": false,
            ""Items"": [
                {
                    ""Id"": null,
                    ""DisplayText"": ""Hired Swords"",
                    ""Url"": ""hiredswords"",
                    ""Type"": 0
                }
            ],
            ""Groups"": []
        },
        {
            ""Id"": ""category_3"",
            ""DisplayText"": ""Encounters"",
            ""Expanded"": false,
            ""Items"": [
                {
                    ""Id"": 1,
                    ""DisplayText"": ""Random Happenings"",
                    ""Url"": ""encountertype/1"",
                    ""Type"": 1
                },
                {
                    ""Id"": 2,
                    ""DisplayText"": ""Subplots"",
                    ""Url"": ""encountertype/2"",
                    ""Type"": 1
                },
                {
                    ""Id"": 15,
                    ""DisplayText"": ""The Town Cryer in Mordheim"",
                    ""Url"": ""encountertype/15"",
                    ""Type"": 1
                },
                {
                    ""Id"": 21,
                    ""DisplayText"": ""Treasures of the Underground"",
                    ""Url"": ""encountertype/21"",
                    ""Type"": 1
                }
            ],
            ""Groups"": []
        },
        {
            ""Id"": ""category_4"",
            ""DisplayText"": ""Skirmish"",
            ""Expanded"": false,
            ""Items"": [
                {
                    ""Id"": 6,
                    ""DisplayText"": ""Black Powder Misfires"",
                    ""Url"": ""encountertype/6"",
                    ""Type"": 1
                },
                {
                    ""Id"": 13,
                    ""DisplayText"": ""Stupidity"",
                    ""Url"": ""encountertype/13"",
                    ""Type"": 1
                },
                {
                    ""Id"": 14,
                    ""DisplayText"": ""Animosity"",
                    ""Url"": ""encountertype/14"",
                    ""Type"": 1
                }
            ],
            ""Groups"": [
                {
                    ""Id"": ""Crit_"",
                    ""DisplayText"": ""Critical Hits"",
                    ""Expanded"": false,
                    ""Items"": [
                        {
                            ""Id"": 8,
                            ""DisplayText"": ""Missile Weapons"",
                            ""Url"": ""encountertype/8"",
                            ""Type"": 1
                        },
                        {
                            ""Id"": 9,
                            ""DisplayText"": ""Bludgeon Weapons"",
                            ""Url"": ""encountertype/9"",
                            ""Type"": 1
                        },
                        {
                            ""Id"": 10,
                            ""DisplayText"": ""Bladed Weapons"",
                            ""Url"": ""encountertype/10"",
                            ""Type"": 1
                        },
                        {
                            ""Id"": 11,
                            ""DisplayText"": ""Unarmed"",
                            ""Url"": ""encountertype/11"",
                            ""Type"": 1
                        },
                        {
                            ""Id"": 12,
                            ""DisplayText"": ""Thrusting Weapons"",
                            ""Url"": ""encountertype/12"",
                            ""Type"": 1
                        },
                        {
                            ""Id"": 19,
                            ""DisplayText"": ""Flexible Weapons"",
                            ""Url"": ""encountertype/19"",
                            ""Type"": 1
                        }
                    ],
                    ""Groups"": []
                }
            ]
        },
        {
            ""Id"": ""category_5"",
            ""DisplayText"": ""Post-Battle Sequence"",
            ""Expanded"": false,
            ""Items"": [
                {
                    ""Id"": 3,
                    ""DisplayText"": ""Power in the Stones"",
                    ""Url"": ""encountertype/3"",
                    ""Type"": 1
                },
                {
                    ""Id"": 4,
                    ""DisplayText"": ""Using Stones"",
                    ""Url"": ""encountertype/4"",
                    ""Type"": 1
                },
                {
                    ""Id"": 5,
                    ""DisplayText"": ""Random Mutations"",
                    ""Url"": ""encountertype/5"",
                    ""Type"": 1
                },
                {
                    ""Id"": 7,
                    ""DisplayText"": ""Rewards of the Shadowlord"",
                    ""Url"": ""encountertype/7"",
                    ""Type"": 1
                },
                {
                    ""Id"": 18,
                    ""DisplayText"": ""Witch Hunter Rabble Rousing"",
                    ""Url"": ""encountertype/18"",
                    ""Type"": 1
                },
                {
                    ""Id"": 20,
                    ""DisplayText"": ""Serious Injuries"",
                    ""Url"": ""encountertype/20"",
                    ""Type"": 1
                }
            ],
            ""Groups"": [
                {
                    ""Id"": ""Sawbones_"",
                    ""DisplayText"": ""Sawbones"",
                    ""Expanded"": false,
                    ""Items"": [
                        {
                            ""Id"": 16,
                            ""DisplayText"": ""Limb Surgery"",
                            ""Url"": ""encountertype/16"",
                            ""Type"": 1
                        },
                        {
                            ""Id"": 17,
                            ""DisplayText"": ""Brain Surgery"",
                            ""Url"": ""encountertype/17"",
                            ""Type"": 1
                        }
                    ],
                    ""Groups"": []
                }
            ]
        }
    ]
}";


        public async Task<DiceChart> GetDiceChartAsync(int diceChartId)
        {
            var diceChart = new DiceChart
            {
                Description = "Random happening",
                Id = diceChartId,
                Dice = "D6",
                Name = "Catacombs",
                MinNumber = 1,
                MaxNumber = 6,
                DiceTypeId = 4,
                NumberOfDice = 1,
                DiceResults = new List<DiceResult>
                {
                    new DiceResult
                    {
                        Id = 19,
                        Description = "A helmet",
                        ResultNumber = 1,
                        DiceChartId = 4
                    },
                    new DiceResult
                    {
                        Id = 20,
                        Description = "A small pouch containing 2D6 gold crowns",
                        ResultNumber = 2,
                        DiceChartId = 4
                    },
                    new DiceResult
                    {
                        Id = 21,
                        Description = "A lantern",
                        ResultNumber = 3,
                        DiceChartId = 4
                    },
                    new DiceResult
                    {
                        Id = 22,
                        Description = "A net",
                        ResultNumber = 4,
                        DiceChartId = 4
                    },
                    new DiceResult
                    {
                        Id = 23,
                        Description = "A vial of Black Lotus",
                        ResultNumber = 5,
                        DiceChartId = 4
                    },
                    new DiceResult
                    {
                        Id = 24,
                        Description = "A sword",
                        ResultNumber = 6,
                        DiceChartId = 4
                    }
                }
            };

            return diceChart;
        }

        public async Task<DiceType> GetDiceTypeAsync(int diceTypeId)
        {
            switch (diceTypeId)
            {
                case 4:
                    return new DiceType
                    {
                        Type = Enums.Die.D6,
                        DisplayName = "D6",
                        MinNumber = 1,
                        MaxNumber = 6
                    };
                case 9:
                    return new DiceType
                    {
                        Type = Enums.Die.D66,
                        DisplayName = "D66",
                        MinNumber = 1,
                        MaxNumber = 66
                    };
                default:
                    return null;
            }
        }

        public async Task<List<DiceType>> GetDiceTypesAsync()
        {
            return new List<DiceType>
            {
                new DiceType
                {
                    Type = Enums.Die.D6,
                    DisplayName = "D6",
                    MinNumber = 1,
                    MaxNumber = 6
                },
                new DiceType
                {
                    Type = Enums.Die.D66,
                    DisplayName = "D66",
                    MinNumber = 1,
                    MaxNumber = 66
                }
            };
        }

        public async Task<Encounter> GetEncounterAsync(int encounterTypeId, int resultNumber)
        {
            var encounter = new Encounter
            {
                ResultNumber = 2,
                BottomText = "Bottom text",
                Description = "Unfortunately for the warbands involved, the scent of blood has brought the attention of one of Khorne's minions. Reality is breached as a vicious Bloodletter emerges from the Realm of Chaos to shed even more blood for its master. The Bloodletter has the following characteristics and special rules:",
                Name = "Blood for the Blood God!",
                EncounterTypeId = encounterTypeId,
                DiceChart = await GetDiceChartAsync(4)
            };

            return encounter;
        }

        public async Task<EncounterType> GetEncounterTypeAsync(int id)
        {
            var encounterType = new EncounterType
            {
                Id = 1,
                Name = "RandomHappening",
                DisplayName = "Random Happening",
                NumberOfDice = 1,
                DiceType = new DiceType
                {
                    DisplayName = "D66",
                    MinNumber = 1,
                    MaxNumber = 66,
                    Id = 9,
                    Type = Enums.Die.D66
                }

            };
            return encounterType;
        }

        public async Task<List<Grade>> GetGradesAsync()
        {
            return new List<Grade>
            {
                new Grade
                {
                    Id = 1,
                    Name = "1a",
                    Description = "Official"
                },
                new Grade
                {
                    Id = 2,
                    Name = "1b",
                    Description = "Unofficial"
                },
                new Grade
                {
                    Id = 3,
                    Name = "1c",
                    Description = "Experimental"
                },
                new Grade
                {
                    Id = 4,
                    Name = "2a",
                    Description = "Reliable"
                },
                new Grade
                {
                    Id = 5,
                    Name = "2b",
                    Description = "Supplemental"
                },
                new Grade
                {
                    Id = 6,
                    Name = "3",
                    Description = "Draft"
                }
            };
        }

        public async Task<List<HiredSword>> GetHiredSwordsAsync()
        {
            return new List<HiredSword>
            {
                new HiredSword
                {
                     Active = true,
                     Id = 1,
                     Name = "Arabian Merchant",
                     Description = "From the lands of eternal desert they come, crossing the sea to reach the Empire, in search of the city spoken of in frightened whispers and imagined in childhood nightmares; Mordheim – City of the Damned.<br /><br />Not all hirelings are warriors and the merchants of Araby are not known for their martial prowess. Rather they are advisers, treasure seekers and collectors of the arcane. Found within the shady bazaars of seldom trodden streets and darkened taverns, they have an uncanny knack of finding the best equipment for the best price, tapping into the vein-like underworld network of black markets and foreign traders providing for any would-be adventurers.<br /><br />Experts in treasure and antiques, they seek their own fortune in the forgotten artefacts buried deep beneath the city but require a warband’s protection. Reciprocal then is this relationship. Although keen to avoid conflict, their employers’ keep them close at hand, as a smooth talking merchant is not to be trusted when treasure and glory is at stake…",
                     HireFee = 20,
                     UpkeepCost = 10,
                     CompatabilityDescription = "The Arabian Merchant may be hired by Lawful, Lawful / Neutral and Neutral warbands.",
                     ProfileId = 8,
                     GradeId = 1,
                     SourceId = 47,
                     Rating = "An Arabian Merchant increases a warband's rating by 10 points plus 1 point for each Experience point the Arabian Merchant has.",
                     Source = new Source
                     {
                          Id = 1,
                           Key = "Key1",
                            Name = "Source1",
                             PdfUrl = "https://broheim.net"
                     },
                     Grade = new Grade
                     {
                          Id = 1,
                           Name = "1a",
                            Description = "1a"
                     }
                },
                new HiredSword
                {
                    Active = true,
                    Id = 2,
                    Name = "Beast Hunter",
                    Description = "The Beast Hunter is a dark wanderer, full of mystery and self-loathing. His is a woeful tale. Kith and kin slaughtered by the foul Beastmen of the wild. He is one of many such men who have been driven to the very edge by their experiences, yearning only now for unquenchable revenge against those that destroyed their once normal lives. They bedeck themselves in the skins of their foes and take on a truly frightening aspect. It is a stout captain indeed who hires such \"wild men\" of the forest but their hunter's skills are without equal and their raw strength in combat is too awesome to ignore. Dangerous and ferocious, ideal qualities for survival in the dark, unbridled wilds.",
                    HireFee = 35,
                    UpkeepCost = 15,
                    CompatabilityDescription = "Any warband other than Skaven, Beastmen, Undead, Orcs & Goblins, Possessed and Carnival of Chaos may hire a Beast Hunter.",
                    ProfileId = 9,
                    GradeId = 1,
                    SourceId = 53,
                    Rating = "A Beast Hunter increases the warband’s rating by 18 points plus 1 point for each Experience point he has.",
                     Source = new Source
                     {
                          Id = 2,
                           Key = "Key2",
                            Name = "Source2",
                             PdfUrl = "https://broheim.net"
                     },
                     Grade = new Grade
                     {
                          Id = 2,
                           Name = "1b",
                            Description = "1b"
                     }
                }
            };
        }

        public async Task<Menu> GetMenuAsync()
        {
            var menu = System.Text.Json.JsonSerializer.Deserialize<Menu>(_dummyMenuJson);
            //var menu = new Menu
            //{

            //};
            return menu;
        }

        public async Task<Monster> GetMonsterAsync(int monsterId)
        {
            return new Monster
            {
                Id = monsterId,
                Name = "Bloodletter",
                Description = "The Bloodletter will seek out the nearest close combat and join in, drawn by the clash of steel. The Deamon has a number of Attacks equal to the number of opponents it is fighting (down to a minimum of 2 Attacks). It will split its attacks amongst the opponents, and no matter how many warriors are involved it may roll to hit each one at least once. It will also prevent an opponent from talking any other warrior <i>out of action</i> in the massed combat, as they will be too concerned with the Daemon to finish off their other enemy!<br/><br/>If there are no ongoing close combats within range, it will charge the model with the highest Weapon Skill in order to do battle with a worthy opponent. If there are no enemies within charge range, the Daemon will run towards the nearest warrior, eager to do battle. The Daemon will stay for D6 turns after which it will dissappear.",
                ProfileId = 1,
                Profile = new Profile
                {
                    Id = 1,
                    Name = "Bloodletter",
                    Movement = "4",
                    Attacks = "2",
                    BallisticSkill = "0",
                    Initiative = "5",
                    Leadership = "6",
                    Strength = "7",
                    Toughness = "5",
                    WeaponSkill = "6",
                    Wounds = "3"
                }
            };
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

        public async Task<List<Warband>> GetWarbandsAsync()
        {
            return new List<Warband>
            {
                new Warband
                {
                    Id = 1,
                     Name = "Averlanders",
                     RaceId = 1,
                     CompatibleHiredSwordIds = new List<int>
                     {
                         1, 2, 3, 4, 5
                     }
                },
                new Warband
                {
                    Id = 2,
                    Name = "Beastmen Raiders",
                    RaceId = 2,
                    CompatibleHiredSwordIds = new List<int>
                    {
                        6, 7
                    }
                },
                new Warband
                {
                    Id = 3,
                    Name = "Carnival of Chaos",
                    RaceId = 3,
                    CompatibleHiredSwordIds = new List<int>
                    {
                        6, 7
                    }
                },
                new Warband
                {
                    Id = 4,
                    Name = "Cult of the Possessed",
                    RaceId = 3,
                    CompatibleHiredSwordIds = new List<int>
                    {
                        6, 7
                    }
                }
            };
        }

        public async Task LoadCachesAsync()
        {

        }
    }
}
