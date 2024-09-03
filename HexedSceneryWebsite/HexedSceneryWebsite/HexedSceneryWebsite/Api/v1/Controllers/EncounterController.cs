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
    public class EncounterController : ControllerBase
    {
        private readonly HexedSceneryContext _context;
        private readonly IMapper _mapper;

        public EncounterController(HexedSceneryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("encounterType/{encounterTypeId}")]
        [ApiKey]
        public IEnumerable<Encounter> GetByEncounterType(int encounterTypeId)
        {
            var dataItems = _context.Encounters.Where(m => m.EncounterTypeId == encounterTypeId);
            var encounters = _mapper.Map<List<Encounter>>(dataItems);
            return encounters;
        }

        [HttpGet("{id}")]
        [ApiKey]
        public Encounter GetByResult(int resultNumber)
        {
            var dataItem = _context.Encounters.Include(m => m.DiceChart).Include(m => m.EncounterType).Include(m => m.Monster).FirstOrDefault(m => m.ResultNumber == resultNumber);
            var encounter = _mapper.Map<Encounter>(dataItem);
            return encounter;
        }
    }
}
