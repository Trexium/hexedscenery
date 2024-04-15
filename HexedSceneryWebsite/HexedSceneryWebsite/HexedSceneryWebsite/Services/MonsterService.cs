using AutoMapper;
using HexedSceneryCommon.Mordheim;
using HexedSceneryData.Data;
using Microsoft.EntityFrameworkCore;

namespace HexedSceneryWebsite.Services
{
    public interface IMonsterService
    {
        Task<Monster> Get(int id);
    }

    public class MonsterService : IMonsterService
    {
        private readonly HexedSceneryContext _context;
        private readonly IMapper _mapper;

        public MonsterService(HexedSceneryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Monster> Get(int id)
        {
            try
            {
                var monster = await _context.Monsters
                    .Include(m => m.MonsterSpecialRules)
                        .ThenInclude(m => m.SpecialRule)
                    .Include(m => m.MonsterAdditionalProfiles)
                        .ThenInclude(m => m.Profile)
                    .Include(m => m.MonsterSkills)
                        .ThenInclude(m => m.Skill)
                    .Include(m => m.Profile)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (monster != null)
                {
                    return _mapper.Map<Monster>(monster);
                }
            } 
            catch (Exception ex)
            {

            }

            return null;
        }
    }
}
