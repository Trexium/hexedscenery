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
    public class MonsterController : ControllerBase
    {
        private readonly HexedSceneryContext _context;
        private readonly IMapper _mapper;

        public MonsterController(HexedSceneryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ApiKey]
        public IEnumerable<Monster> Get()
        {
            var dataItems = _context.Monsters
                .Include(m => m.MonsterEquipments)
                    .ThenInclude(m => m.Equipment)
                .Include(m => m.MonsterAdditionalProfiles)
                    .ThenInclude(m => m.Profile)
                .Include(m => m.MonsterSkills)
                    .ThenInclude(m => m.Skill)
                .Include(m => m.MonsterSpecialRules)
                    .ThenInclude(m => m.SpecialRule)
                .Include(m => m.Profile)
                .ToList();
            var monsters = _mapper.Map<List<Monster>>(dataItems);
            return monsters;
        }

        // GET api/<MonsterController>/5
        [HttpGet("{id}")]
        [ApiKey]
        public Monster Get(int id)
        {
            var dataItem = _context.Monsters
                .Include(m => m.MonsterEquipments)
                    .ThenInclude(m => m.Equipment)
                .Include(m => m.MonsterAdditionalProfiles)
                    .ThenInclude(m => m.Profile)
                .Include(m => m.MonsterSkills)
                    .ThenInclude(m => m.Skill)
                .Include(m => m.MonsterSpecialRules)
                    .ThenInclude(m => m.SpecialRule)
                .Include(m => m.Profile)
                .FirstOrDefault(m => m.Id == id);
                
            
            var monster = _mapper.Map<Monster>(dataItem);
            return monster;
        }
    }
}
