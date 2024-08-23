
using HexedSceneryCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryData.Services
{
    public interface IEncounterService
    {
        List<EncounterType> GetEncounterTypes();
    }
    public class EncounterService : IEncounterService
    {
        public List<EncounterType> GetEncounterTypes()
        {
            throw new NotImplementedException();
        }
    }
}
