using HexedSceneryData.Data;
using HexedSceneryData.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HexedSceneryWebsite.Api.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiceController : ControllerBase
    {
        private readonly HexedSceneryContext _context;

        public DiceController(HexedSceneryContext context)
        {
            _context = context;
        }

        // GET: api/<DiceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DiceController>/5
        [HttpGet("{id}")]
        public DiceType Get(int id)
        {
            var diceType = _context.DiceTypes.FirstOrDefault(m => m.Id == id);
            return diceType;
        }
    }
}
