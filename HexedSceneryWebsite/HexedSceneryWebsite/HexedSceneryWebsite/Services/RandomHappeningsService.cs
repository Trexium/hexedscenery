using AutoMapper;
using HexedSceneryCommon.Mordheim;
using HexedSceneryData.Data;
using Microsoft.EntityFrameworkCore;
using Common = HexedSceneryCommon.Mordheim;

namespace HexedSceneryWebsite.Services
{
    public interface IRandomHappeningsService
    {
        Task<Common.Encounter> GetEncounter(int resultNumber, int encounterType);
        Task<Common.Encounter> GetRandomEncounter(int encounterType);
    }

    public class RandomHappeningsService : IRandomHappeningsService
    {
        private readonly HexedSceneryContext _context;
        private readonly IMapper _mapper;
        public RandomHappeningsService(HexedSceneryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                    encounterNumber = (randomGenerator.Next(1, 6) * 10) + randomGenerator.Next(1, 6);
                    break;
                case 2: // Subplots
                    encounterNumber = randomGenerator.Next(1, 6) + randomGenerator.Next(1, 6) + randomGenerator.Next(1, 6);
                    break;
                case 3: // Power of the stones
                    encounterNumber = randomGenerator.Next(1, 6) + randomGenerator.Next(1, 6);
                    break;
                case 4: // Using stones
                    encounterNumber = randomGenerator.Next(1, 6);
                    break;
                case 5: // Random mutations table
                    encounterNumber = (randomGenerator.Next(1, 6) * 10) + randomGenerator.Next(1, 6);
                    break;
            }

            return await GetEncounter(encounterNumber, encounterType);
        }
    }
}
