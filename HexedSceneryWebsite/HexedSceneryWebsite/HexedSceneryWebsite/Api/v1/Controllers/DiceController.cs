using AutoMapper;
using HexedSceneryData.Data;
using HexedSceneryWebsite.Api.Auth;
using HexedSceneryWebsite.Api.v1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HexedSceneryWebsite.Api.v1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiceController : ControllerBase
    {
        private readonly HexedSceneryContext _context;
        private readonly IMapper _mapper;

        public DiceController(HexedSceneryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET api/<DiceController>/5
        [HttpGet("{id}")]
        [ApiKey]
        public DiceType Get(int id)
        {
            var dataItem = _context.DiceTypes.FirstOrDefault(m => m.Id == id);
            var diceType = _mapper.Map<DiceType>(dataItem);
            return diceType;
        }
    }
}
