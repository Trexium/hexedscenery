using HexedSceneryData.Data;
using HexedSceneryData.Models;
using HexedSceneryWebsite.Api.v1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HexedSceneryWebsite.Api.Auth;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HexedSceneryWebsite.Api.v1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly HexedSceneryContext _context;

        public CategoryController(HexedSceneryContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ApiKey]
        public IEnumerable<TableCategory> Get()
        {
            //return new string[] { "value1", "value2" };
            return _context.TableCategories.Where(m => m.Active == true && !string.IsNullOrEmpty(m.DisplayName)).ToList();
        }

        [HttpGet("includeChildren")]
        [ApiKey]
        public IEnumerable<TableCategory> GetWithChildren()
        {
            return _context.TableCategories.Include(m => m.EncounterTypes).Where(m => m.Active == true);
        }
    }
}
