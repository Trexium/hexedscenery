using HexedSceneryApiClient.Services;
using HexedSceneryMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Helpers
{
    public interface IEncounterHandler
    {
        Task<Encounter> GetEncounter(int id);
    }

    public class EncounterHandler : IEncounterHandler
    {
        private readonly IEncounterService _encounterService;

        public EncounterHandler(IEncounterService encounterService)
        {
            _encounterService = encounterService;
        }

        public Task<Encounter> GetEncounter(int id)
        {
            throw new NotImplementedException();
        }
    }
}
