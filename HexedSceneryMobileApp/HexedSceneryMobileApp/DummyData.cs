using HexedSceneryCommon.Models;
using HexedSceneryData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp
{
    public class DummyData : IEncounterService, IGamePlayService, IPostGameService
    {
        public List<EncounterType> GetEncounterTypes()
        {
            var testdata = new List<EncounterType>();
            testdata.Add(new EncounterType
            {
                Id = 1,
                Name = "Random Happenings",
                DiceType = HexedSceneryCommon.Enums.DiceType.D66,
                NumberOfDice = 1
            });
            testdata.Add(new EncounterType
            {
                Id = 2,
                Name = "Subplots",
                DiceType = HexedSceneryCommon.Enums.DiceType.D6,
                NumberOfDice = 3
            });
            testdata.Add(new EncounterType
            {
                Id = 3,
                Name = "Town Cryer",
                DiceType = HexedSceneryCommon.Enums.DiceType.D6,
                NumberOfDice = 2
            });
            testdata.Add(new EncounterType
            {
                Id = 4,
                Name = "Treasures of the Underground",
                DiceType = HexedSceneryCommon.Enums.DiceType.D6,
                NumberOfDice = 1
            });
            
            return testdata;
        }

        public List<GamePlayTableType> GetGamePlayTableTypes()
        {
            var testdata = new List<GamePlayTableType>();
            testdata.Add(new GamePlayTableType
            {
                Id = 1,
                Name = "Animosity",
                DiceType = HexedSceneryCommon.Enums.DiceType.D6,
                NumberOfDice = 1
            });
            testdata.Add(new GamePlayTableType
            {
                Id = 2,
                Name = "Blackpowder Misfires",
                DiceType = HexedSceneryCommon.Enums.DiceType.D6,
                NumberOfDice = 1
            });
            testdata.Add(new GamePlayTableType
            {
                Id = 3,
                Name = "Critical Hits",
                DiceType = HexedSceneryCommon.Enums.DiceType.D6,
                NumberOfDice = 1
            });
            testdata.Add(new GamePlayTableType
            {
                Id = 4,
                Name = "Stupidity",
                DiceType = HexedSceneryCommon.Enums.DiceType.D6,
                NumberOfDice = 1
            });
            return testdata;
        }

        public List<PostGameTableType> GetPostGameTableTypes()
        {
            var testdata = new List<PostGameTableType>();
            testdata.Add(new PostGameTableType
            {
                Id = 1,
                Name = "Power in the Stones",
                DiceType = HexedSceneryCommon.Enums.DiceType.D6,
                NumberOfDice = 2
            });
            testdata.Add(new PostGameTableType
            {
                Id = 2,
                Name = "Rewards of the Shadowlord",
                DiceType = HexedSceneryCommon.Enums.DiceType.D6,
                NumberOfDice = 2
            });
            testdata.Add(new PostGameTableType
            {
                Id = 3,
                Name = "Random Mutations",
                DiceType = HexedSceneryCommon.Enums.DiceType.D66,
                NumberOfDice = 1
            });
            testdata.Add(new PostGameTableType
            {
                Id = 4,
                Name = "Sawbones",
                DiceType = HexedSceneryCommon.Enums.DiceType.D6,
                NumberOfDice = 2
            });
            testdata.Add(new PostGameTableType
            {
                Id = 5,
                Name = "Serious Injuries",
                DiceType = HexedSceneryCommon.Enums.DiceType.D66,
                NumberOfDice = 1
            });
            testdata.Add(new PostGameTableType
            {
                Id = 6,
                Name = "Rabble Rousing",
                DiceType = HexedSceneryCommon.Enums.DiceType.D6,
                NumberOfDice = 2
            });

            return testdata;
        }
    }
}
