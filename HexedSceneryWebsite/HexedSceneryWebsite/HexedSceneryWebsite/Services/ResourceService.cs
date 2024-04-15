using HexedSceneryData.Data;

namespace HexedSceneryWebsite.Services
{
    public enum Icon
    {
        CritMissileWeapons,
        CritBludgeonWeapons,
        CritBladedWeapons,
        CritUnarmedCombat,
        CritThrustingWeapons
    }
    public interface IResourceService
    {
        string GetEncounterType(int encounterTypeId);
    }
    public class ResourceService : IResourceService
    {
        private readonly HexedSceneryContext _context;

        public ResourceService(HexedSceneryContext context)
        {
            _context = context;
        }

        public string GetEncounterType(int encounterTypeId)
        {
            return _context.EncounterTypes.FirstOrDefault(m => m.Id == encounterTypeId)?.DisplayName;
            string result = null;

            switch (encounterTypeId)
            {
                case 1:
                    result = "Random happenings";
                    break;
                case 2:
                    result = "Subplots";
                    break;
                case 3:
                    result = "Power in the Stones";
                    break;
                case 4:
                    result = "Using stones";
                    break;
                case 5:
                    result = "Random mutations";
                    break;
                case 6:
                    result = "Misfires";
                    break;
                case 7:
                    result = "Rewards of the Shadowlord";
                    break;
                case 8:
                    result = "Missile";
                    break;
                case 9:
                    result = "Bludgeon";
                    break;
                case 10:
                    result = "Bladed";
                    break;
                case 11:
                    result = "Unarmed";
                    break;
                case 12:
                    result = "Thrusting";
                    break;
                case 13:
                    result = "Stupidity";
                    break;
                case 14:
                    result = "Animosity";
                    break;

            }

            return result;
        }
    }
}
