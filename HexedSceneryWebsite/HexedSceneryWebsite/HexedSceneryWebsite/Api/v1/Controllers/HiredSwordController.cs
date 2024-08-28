using HexedSceneryData.Data;
using HexedSceneryData.Models;
using HexedSceneryWebsite.Api.Auth;
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

        public HiredSwordController(HexedSceneryContext context)
        {
            _context = context;
        }

        // GET: api/<HiredSwordController>
        [HttpGet]
        [ApiKey]
        public IEnumerable<HiredSword> Get()
        {
            return _context.HiredSwords;
        }

        [HttpGet]
        [ApiKey]
        public IEnumerable<HiredSword> Get([FromQuery] int? warbandId, [FromQuery] int? minGradeId, [FromQuery] int? maxGradeId)
        {
            return _context.HiredSwords.Include(m => m.HiredSwordCompatibleWarbands).Where(m => m.Active && (!warbandId.HasValue || m.HiredSwordCompatibleWarbands.Any(w => w.WarbandId == warbandId) && (!minGradeId.HasValue || m.GradeId >= minGradeId) && (!maxGradeId.HasValue || m.GradeId <= maxGradeId)));
        }

        // GET api/<HiredSwordController>/5
        [HttpGet("{id}")]
        [ApiKey]
        public HiredSword Get(int id)
        {
            return _context.HiredSwords
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
        }
    }
}
