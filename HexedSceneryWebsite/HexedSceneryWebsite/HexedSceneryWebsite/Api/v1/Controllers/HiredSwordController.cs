using AutoMapper;
using HexedSceneryData.Data;
using HexedSceneryWebsite.Api.Auth;
using HexedSceneryWebsite.Api.v1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HexedSceneryWebsite.Api.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HiredSwordController : ControllerBase
    {
        private readonly HexedSceneryContext _context;
        private readonly IMapper _mapper;

        public HiredSwordController(HexedSceneryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<HiredSwordController>
        [HttpGet]
        [ApiKey]
        public IEnumerable<HiredSword> Get()
        {
            var dataItems = _context.HiredSwords;
            var hiredSwords = _mapper.Map<List<HiredSword>>(dataItems);
            return hiredSwords;
        }

        [HttpGet]
        [ApiKey]
        public IEnumerable<HiredSword> Get([FromQuery] int? warbandId, [FromQuery] int? minGradeId, [FromQuery] int? maxGradeId)
        {
            var dataItems = _context.HiredSwords.Include(m => m.HiredSwordCompatibleWarbands).Where(m => m.Active && (!warbandId.HasValue || m.HiredSwordCompatibleWarbands.Any(w => w.WarbandId == warbandId) && (!minGradeId.HasValue || m.GradeId >= minGradeId) && (!maxGradeId.HasValue || m.GradeId <= maxGradeId)));
            var hiredSwords = _mapper.Map<List<HiredSword>>(dataItems);
            return hiredSwords;
        }

        // GET api/<HiredSwordController>/5
        [HttpGet("{id}")]
        [ApiKey]
        public HiredSword Get(int id)
        {
            var dataItem = _context.HiredSwords
                .Include(m => m.HiredSwordEquipments)
                .Include(m => m.Grade)
                .Include(m => m.HiredSwordAdditionalProfiles)
                .Include(m => m.HiredSwordCompatibleWarbands)
                .Include(m => m.HiredSwordSkills)
                .Include(m => m.HiredSwordSkillTypes)
                .Include(m => m.HiredSwordSpecialRules)
                .Include(m => m.Profile)
                .Include(m => m.Source)
                .FirstOrDefault(m => m.Active && m.Id == id);
            var hiredSword = _mapper.Map<HiredSword>(dataItem);
            return hiredSword;
        }
    }
}
