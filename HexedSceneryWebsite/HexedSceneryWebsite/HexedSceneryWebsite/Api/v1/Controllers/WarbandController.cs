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
    public class WarbandController : ControllerBase
    {
        private readonly HexedSceneryContext _context;
        private readonly IMapper _mapper;

        public WarbandController(HexedSceneryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ApiKey]
        public IEnumerable<Warband> Get()
        {
            var dataItems = _context.Warbands
                    .Include(m => m.Race)
                        .ToList();
            var warbands = _mapper.Map<List<Warband>>(dataItems);

            foreach (var warband in warbands)
            {
                warband.CompatibleHiredSwordIds = _context.HiredSwordCompatibleWarbands.Where(m => m.WarbandId == warband.Id).Select(m => m.HiredSwordId.Value).ToList();
            }

            return warbands;
        }
    }
}
