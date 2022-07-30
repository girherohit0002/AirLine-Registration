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
        // GET: api/<FlightController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = from Flight in ac.Flights
                           select new
                           {
                               FlightNumber = Flight.FlightNumber,
                               timeOfArrival = Flight.TimeOfArr,
                               timeOfDeparture = Flight.TimeOfDept,
                               Duration = Flight.Duration,
                               From = Flight.ArrCity,
                               To = Flight.DepCity,
                               Price = Flight.Price
                           };
                return Ok(data);
            }catch(Exception ex)
            {
                return BadRequest("The exception occured is " + ex);
            }
        }

        // GET api/<FlightController>/5
        [HttpGet()]
        [Route("List")]
        public IActionResult GetById(string flightnumber)
        {
            try
            {
                var flight = from Flight in ac.Flights where Flight.FlightNumber == flightnumber select Flight;
                return Ok(flight);
            }
            catch(Exception ex)
            {
                return BadRequest("The exception ouccured is " + ex);
            }
        }

        // POST api/<FlightController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FlightController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FlightController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
