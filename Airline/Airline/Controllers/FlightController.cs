using Airline.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Airline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        AirLineContext ac = new AirLineContext();
        // GET: api/<FlightsController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (ac)
                {
                    return Ok(ac.Flights.ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

            // GET api/<FlightsController>/5
            [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FlightsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FlightsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FlightsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
