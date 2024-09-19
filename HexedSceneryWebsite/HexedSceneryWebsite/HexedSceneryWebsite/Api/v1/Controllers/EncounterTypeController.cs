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
    public class EncounterTypeController : ControllerBase
    {
        private readonly HexedSceneryContext _context;
        private readonly IMapper _mapper;

        public EncounterTypeController(HexedSceneryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ApiKey]
        public IEnumerable<EncounterType> Get()
        {
            var dataItems = _context.EncounterTypes.Include(m => m.DiceType).Where(m => m.Active == true).ToList();
            var encounterTypes = _mapper.Map<List<EncounterType>>(dataItems);
            return encounterTypes;
        }

        [HttpGet("category/{categoryId}")]
        [ApiKey]
        public IEnumerable<EncounterType> GetByCategory(int categoryId)
        {
            var dataItems = _context.EncounterTypes.Where(m => m.Active == true && m.TableCategoryId == categoryId);
            var encounterTypes = _mapper.Map<List<EncounterType>>(dataItems);
            return encounterTypes;
        }

        [HttpGet("{id}")]
        [ApiKey]
        public EncounterType Get(int id)
        {
            var dataItem = _context.EncounterTypes.Include(m => m.DiceType).Include(m => m.TableCategory).FirstOrDefault(m => m.Active == true && m.Id == id);
            var encounterType = _mapper.Map<EncounterType>(dataItem);
            return encounterType;
        }
    }
}
