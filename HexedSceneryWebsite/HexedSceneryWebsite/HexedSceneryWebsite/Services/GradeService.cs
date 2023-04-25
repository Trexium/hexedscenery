using AutoMapper;
using HexedSceneryData.Data;
using Microsoft.EntityFrameworkCore;
using Common = HexedSceneryCommon.Mordheim;

namespace HexedSceneryWebsite.Services
{
    public interface IGradeService
    {
        public List<Common.Grade> GetAll();
    }

    public class GradeService : IGradeService
    {
        private readonly IMapper _mapper;
        private readonly HexedSceneryContext _context;

        public GradeService(IMapper mapper, HexedSceneryContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<Common.Grade> GetAll()
        {
            var mappedResponse = _mapper.Map<List<Common.Grade>>(_context.Grades.ToList());
            return mappedResponse;
        }
    }
}
