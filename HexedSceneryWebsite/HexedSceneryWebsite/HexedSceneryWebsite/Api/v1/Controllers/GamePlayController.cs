using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HexedSceneryWebsite.Api.v1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GamePlayController : ControllerBase
    {
        // GET: api/<GamePlayController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GamePlayController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GamePlayController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GamePlayController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GamePlayController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
