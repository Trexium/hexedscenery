using AutoMapper;
using HexedSceneryData.Data;
using Microsoft.EntityFrameworkCore;
using Common = HexedSceneryCommon.Mordheim;

namespace HexedSceneryWebsite.Services
{
    public interface IHiredSwordService
    {
        List<Common.HiredSword> GetAll();
        List<Common.HiredSword> GetAllWithFilter(int warbandId, int gradeId);
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

        public List<Common.HiredSword> GetAll()
        {
            var dbResult = _context.HiredSwords
                .Include(hs => hs.Grade)
                .Include(hs => hs.Source)
                .Include(hs => hs.HiredSwordCompatibleWarbands)
                    .ThenInclude(hscw => hscw.Warband)
                .Where(hs => hs.Active).ToList();
            var mappedResponse = _mapper.Map<List<Common.HiredSword>>(dbResult);
            return mappedResponse;
        }

        public List<Common.HiredSword> GetAllWithFilter(int warbandId, int gradeId)
        {
            var dbResult = _context.HiredSwords
                .Include(hs => hs.Grade)
                .Include(hs => hs.Source)
                .Where(hs => hs.Active && 
                    (warbandId == 0 || hs.HiredSwordCompatibleWarbands.Any(hscw => hscw.WarbandId == warbandId)) &&
                    (gradeId == 0 || hs.GradeId == gradeId)
                ).ToList();
            var mappedResponse = _mapper.Map<List<Common.HiredSword>>(dbResult);
            return mappedResponse;
        }
    }
}
