using HexedSceneryCommon.Mordheim;
using HexedSceneryCommon.User;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;

namespace HexedSceneryWebsite.Services
{
    public interface IUserStoredEncountersService
    {
        Task<List<Encounter>> GetUserEncounters(string key);
        Task StoreEncounter(string key, Encounter encounter);
    }

    public class UserStoredEncountersService : IUserStoredEncountersService
    {
        private readonly Dictionary<string, List<Encounter>> _userEncounters;

        public UserStoredEncountersService()
        {
            _userEncounters = new Dictionary<string, List<Encounter>>();
        }

        public async Task<List<Encounter>> GetUserEncounters(string key)
        {
            if (_userEncounters.ContainsKey(key))
            {
                return _userEncounters[key];
            } 
            else if (!key.Contains('_'))
            {
                return _userEncounters.Where(m => m.Key.Contains(key)).SelectMany(m => m.Value).ToList();
            }
            else
            {
                return null;
            }
        }

        public async Task StoreEncounter(string key, Encounter encounter)
        {
            if (!_userEncounters.ContainsKey(key))
            {
                _userEncounters[key] = new List<Encounter>();
            }

            _userEncounters[key].Add(encounter);
        }
    }
}
