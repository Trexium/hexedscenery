using AutoMapper;
using HexedSceneryData.Data;
using HexedSceneryWebsite.Api.Auth;
using HexedSceneryWebsite.Api.v1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HexedSceneryWebsite.Api.v1.Controllers
{
    [Route("api/v1/[controller]")]
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
            var dataItems = _context.HiredSwords
                .Include(m => m.Source)
                .Include(m => m.Grade)
                .ToList();
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
                    .ThenInclude(m => m.Equipment)
                .Include(m => m.Grade)
                .Include(m => m.HiredSwordAdditionalProfiles)
                    .ThenInclude(m => m.Profile)
                .Include(m => m.HiredSwordCompatibleWarbands)
                    .ThenInclude(m => m.Warband)
                .Include(m => m.HiredSwordSkills)
                    .ThenInclude(m => m.Skill)
                .Include(m => m.HiredSwordSkillTypes)
                    .ThenInclude(m => m.SkillType)
                .Include(m => m.HiredSwordSpecialRules)
                    .ThenInclude(m => m.SpecialRule)
                .Include(m => m.Profile)
                .Include(m => m.Source)
                .FirstOrDefault(m => m.Active && m.Id == id);
            var hiredSword = _mapper.Map<HiredSword>(dataItem);
            return hiredSword;
        }
    }
}
