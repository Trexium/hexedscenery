
using HexedSceneryCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryData.Services
{
    public interface IGamePlayService
    {
        List<GamePlayTableType> GetGamePlayTableTypes();
    }
    public class GamePlayService : IGamePlayService
    {
        public List<GamePlayTableType> GetGamePlayTableTypes()
        {
            throw new NotImplementedException();
        }
    }
}
