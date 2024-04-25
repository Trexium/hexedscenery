using AutoMapper;
using HexedSceneryCommon.Mordheim;
using HexedSceneryData.Data;
using Microsoft.EntityFrameworkCore;
using Common = HexedSceneryCommon.Mordheim;

namespace HexedSceneryWebsite.Services
{
    public interface IEncounterService
    {
        Task<Common.Encounter> GetEncounter(int resultNumber, int encounterType);
        Task<Common.Encounter> GetRandomEncounter(int encounterType);
    }

    public class EncounterService : IEncounterService
    {
        private readonly HexedSceneryContext _context;
        private readonly IMapper _mapper;
        private readonly IDiceRollService _diceRollService;
        public EncounterService(HexedSceneryContext context, IMapper mapper, IDiceRollService diceRollService)
        {
            _context = context;
            _mapper = mapper;
            _diceRollService = diceRollService;
        }

        public async Task<Common.Encounter> GetEncounter(int resultNumber, int encounterType)
        {
            try
            {
                var encounter = await _context.Encounters
                .Include(m => m.Monster)
                    .ThenInclude(m => m.MonsterSpecialRules)
                        .ThenInclude(m => m.SpecialRule)
                .Include(m => m.Monster)
                    .ThenInclude(m => m.MonsterAdditionalProfiles)
                        .ThenInclude(m => m.Profile)
                .Include(m => m.Monster)
                    .ThenInclude(m => m.MonsterSkills)
                        .ThenInclude(m => m.Skill)
                .Include(m => m.DiceChart)
                    .ThenInclude(m => m.DiceResults)
                .Include(m => m.Monster)
                    .ThenInclude(m => m.Profile)
                .Include(m => m.Monster)
                    .ThenInclude(m => m.MonsterEquipments)
                        .ThenInclude(m => m.Equipment)
                .FirstOrDefaultAsync(e => e.ResultNumber == resultNumber && e.EncounterTypeId == encounterType);
                if (encounter != null)
                {
                    return _mapper.Map<Common.Encounter>(encounter);
                }
            }
            catch (Exception ex)
            {

            }


            return null;
        }

        public async Task<Encounter> GetRandomEncounter(int encounterType)
        {
            var randomGenerator = new Random();
            int encounterNumber = 0;

            switch (encounterType)
            {
                case 1: // Random happening
                    encounterNumber = _diceRollService.RollD66();
                    break;
                case 2: // Subplots
                    encounterNumber = _diceRollService.RollD6(3);
                    break;
                case 3: // Power of the stones
                    encounterNumber = _diceRollService.RollD6(2);
                    break;
                case 4: // Using stones
                    encounterNumber = _diceRollService.RollD6();
                    break;
                case 5: // Random mutations table
                    encounterNumber = _diceRollService.RollD66();
                    break;
                case 6: // Misfires
                    encounterNumber = _diceRollService.RollD6();
                    break;
                case 7: // Rewards of the Shadowlord
                    encounterNumber = _diceRollService.RollD6(2);
                    break;
                case 8: // Crit_MissileWeapons
                case 9: // Crit_BludgeonWeapons
                case 10: // Crit_BladedWeapons
                case 11: // Crit_UnarmedCombat
                case 12: // Crit_ThrustingWeapons
                case 19: // Crit_FlexibleWeapons
                    encounterNumber = _diceRollService.RollD6();
                    break;
                case 13: // Stupidity
                    encounterNumber = _diceRollService.RollD6();
                    break;
                case 14: // Animosity
                    encounterNumber = _diceRollService.RollD6();
                    break;
                case 15: // TheTownCryerOfMordheim
                    encounterNumber = _diceRollService.RollD6(2);
                    break;
                case 16: // Sawbones_LimbSurgery
                case 17: // Sawbones_BrainSurgery
                    encounterNumber = _diceRollService.RollD6(2);
                    break;
                case 18: // RabbleRousing
                    encounterNumber = _diceRollService.RollD6();
                    break;
                case 20: // SeriousInjuries
                    encounterNumber = _diceRollService.RollD66();
                    break;
                case 21: // TreasuresOfTheUnderground
                    encounterNumber= _diceRollService.RollD6();
                    break;
            }

            return await GetEncounter(encounterNumber, encounterType);
        }
    }
}
