using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace BlueBall.v2.Controllers
{
    //[Route("api/[controller]")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        // GET: api/<BasketController>
        [MapToApiVersion("2.0")]
        [HttpGet]
        public IEnumerable<string> Getv2()
        {
            return new string[] { "basket10", "basket20" };
        }

        // GET api/<BasketController>/5
        [MapToApiVersion("2.0")]
        [HttpGet("{id}")]
        public string Getv2(int id)
        {
            return $"basket{id}";
        }

        // POST api/<BasketController>
        [MapToApiVersion("2.0")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BasketController>/5
        [MapToApiVersion("2.0")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BasketController>/5
        [MapToApiVersion("2.0")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}
