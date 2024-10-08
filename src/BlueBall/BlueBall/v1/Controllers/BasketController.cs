using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace BlueBall.v1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        // GET: api/<BasketController>
        [MapToApiVersion("1.0")]
        [HttpGet]
        public IEnumerable<string> Getv1()
        {
            return new string[] { "basket1", "basket2" };
        }

        // GET api/<BasketController>/5
        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public string Getv1(int id)
        {
            return $"basket{id}";
        }

        // POST api/<BasketController>
        [MapToApiVersion("1.0")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BasketController>/5
        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BasketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}
