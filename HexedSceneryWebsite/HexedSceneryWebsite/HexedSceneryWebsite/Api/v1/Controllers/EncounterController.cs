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
    public class EncounterController : ControllerBase
    {
        private HexedSceneryContext _context;

        public EncounterController(HexedSceneryContext context)
        {
            _context = context;
        }

        [HttpGet("encounterType/{encounterTypeId}")]
        [ApiKey]
        public IEnumerable<Encounter> GetByEncounterType(int encounterTypeId)
        {
            return _context.Encounters.Where(m => m.EncounterTypeId == encounterTypeId);
        }

        [HttpGet("{id}")]
        [ApiKey]
        public Encounter GetByResult(int resultNumber)
        {
            return _context.Encounters.Include(m => m.DiceChart).Include(m => m.EncounterType).Include(m => m.Monster).FirstOrDefault(m => m.ResultNumber == resultNumber);
        }
    }
}
