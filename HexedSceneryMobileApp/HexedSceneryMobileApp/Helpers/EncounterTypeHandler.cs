using HexedSceneryApiClient.Services;
using HexedSceneryMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Helpers
{
    public interface IEncounterTypeHandler
    {
        Task<EncounterType> GetEncounterType(int id);
    }
    public class EncounterTypeHandler : IEncounterTypeHandler
    {
        private readonly IEncounterService _encounterService;

        public EncounterTypeHandler(IEncounterService encounterService)
        {
            _encounterService = encounterService;
        }

        public async Task<EncounterType> GetEncounterType(int id)
        {
            var encounterType = await _encounterService.GetEncounterTypeAsync(id);
            var model = encounterType.ToViewModel();
            return model;
        }
    }
}
