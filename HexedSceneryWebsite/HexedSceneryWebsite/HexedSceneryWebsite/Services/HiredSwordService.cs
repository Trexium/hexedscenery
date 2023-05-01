using AutoMapper;
using HexedSceneryCommon.Mordheim;
using HexedSceneryData.Data;
using Microsoft.EntityFrameworkCore;
using Common = HexedSceneryCommon.Mordheim;

namespace HexedSceneryWebsite.Services
{
    public interface IHiredSwordService
    {
        Task<List<Common.HiredSword>> GetAll();
        Task<List<Common.HiredSword>> GetAllWithFilter(int warbandId, int gradeId);
        Task<Common.HiredSword> Get(int hiredSwordId);
    }
    public class HiredSwordService : IHiredSwordService
    {
        private readonly HexedSceneryContext _context;
        private readonly IMapper _mapper;
        
        public HiredSwordService(HexedSceneryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HiredSword> Get(int hiredSwordId)
        {
            var dbResult = _context.HiredSwords
                .Include(hs => hs.Grade)
                .Include(hs => hs.Source)
                .Include(hs => hs.HiredSwordCompatibleWarbands)
                    .ThenInclude(hscw => hscw.Warband)
                .Where(hs => hs.Id == hiredSwordId).FirstOrDefaultAsync();
            var mappedResponse = _mapper.Map<HiredSword>(await dbResult);
            return mappedResponse;
        }

        public async Task<List<Common.HiredSword>> GetAll()
        {
            var dbResult = _context.HiredSwords
                .Include(hs => hs.Grade)
                .Include(hs => hs.Source)
                .Include(hs => hs.HiredSwordCompatibleWarbands)
                    .ThenInclude(hscw => hscw.Warband)
                .Where(hs => hs.Active).ToListAsync();
            var mappedResponse = _mapper.Map<List<Common.HiredSword>>(await dbResult);
            return mappedResponse;
        }

        public async Task<List<Common.HiredSword>> GetAllWithFilter(int warbandId, int gradeId)
        {
            var dbResult = _context.HiredSwords
                .Include(hs => hs.Grade)
                .Include(hs => hs.Source)
                .Where(hs => hs.Active && 
                    (warbandId == 0 || hs.HiredSwordCompatibleWarbands.Any(hscw => hscw.WarbandId == warbandId)) &&
                    (gradeId == 0 || hs.GradeId == gradeId)
                ).ToListAsync();
            var mappedResponse = _mapper.Map<List<Common.HiredSword>>(await dbResult);
            return mappedResponse;
        }
    }
}
