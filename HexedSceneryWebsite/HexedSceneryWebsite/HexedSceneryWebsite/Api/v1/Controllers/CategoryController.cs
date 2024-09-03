using HexedSceneryData.Data;
using HexedSceneryWebsite.Api.v1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HexedSceneryWebsite.Api.Auth;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HexedSceneryWebsite.Api.v1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly HexedSceneryContext _context;
        private readonly IMapper _mapper;

        public CategoryController(HexedSceneryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ApiKey]
        public IEnumerable<TableCategory> Get()
        {
            var dataItems = _context.TableCategories.Where(m => m.Active == true && !string.IsNullOrEmpty(m.DisplayName)).ToList();
            var categories = _mapper.Map<List<TableCategory>>(dataItems);
            return categories;
        }

        [HttpGet("includeChildren")]
        [ApiKey]
        public IEnumerable<TableCategory> GetWithChildren()
        {
            var dataItems = _context.TableCategories.Include(m => m.EncounterTypes).Where(m => m.Active == true);
            var categories = _mapper.Map<List<TableCategory>>(dataItems);
            return categories;
        }
    }
}
