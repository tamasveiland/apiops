﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlueBall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        // GET: api/<BasketController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "basket1", "basket2" };
        }

        // GET api/<BasketController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"basket{id}";
        }

        // POST api/<BasketController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BasketController>/5
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
