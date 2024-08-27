using HexedSceneryData.Data;
using HexedSceneryData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HexedSceneryWebsite.Api.v1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EncounterTypeController : ControllerBase
    {
        private readonly HexedSceneryContext _context;

        public EncounterTypeController(HexedSceneryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<EncounterType> Get()
        {
            return _context.EncounterTypes.Where(m => m.Active == true).ToList();
        }

        [HttpGet("category/{categoryId}")]
        public IEnumerable<EncounterType> GetByCategory(int categoryId)
        {
            return _context.EncounterTypes.Where(m => m.Active == true && m.TableCategoryId == categoryId);
        }

        [HttpGet("{id}")]
        public EncounterType Get(int id)
        {
            return _context.EncounterTypes.Include(m => m.DiceType).Include(m => m.TableCategory).FirstOrDefault(m => m.Active == true && m.Id == id);
        }
    }
}
