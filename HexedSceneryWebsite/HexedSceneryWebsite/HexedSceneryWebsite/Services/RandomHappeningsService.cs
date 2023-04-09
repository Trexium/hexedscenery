using AutoMapper;
using HexedSceneryCommon.Mordheim;
using HexedSceneryData.Data;
using Microsoft.EntityFrameworkCore;
using Common = HexedSceneryCommon.Mordheim;

namespace HexedSceneryWebsite.Services
{
    public interface IRandomHappeningsService
    {
        Common.Encounter GetEncounter(int resultNumber);
        Common.Encounter GetRandomEncounter();
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

        public Common.Encounter GetEncounter(int resultNumber)
        {
            var encounter = _context.Encounters
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
                .FirstOrDefault(e => e.ResultNumber == resultNumber);
            if (encounter != null)
            {
                return _mapper.Map<Common.Encounter>(encounter);
            }

            return null;
        }

        public Encounter GetRandomEncounter()
        {
            var randomGenerator = new Random();
            var firstNumber = randomGenerator.Next(1, 6);
            var secondNumber = randomGenerator.Next(1, 6);
            var encounterNumber = (firstNumber * 10) + secondNumber;

            return GetEncounter(encounterNumber);
        }
    }
}
