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
    [Route("GetAll")]
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
                               Price = Flight.Price,
                               EconomicalSeat = Flight.SeatsEco,
                               BuisenessSeat = Flight.SeatsBussiness
                           };
                return Ok(data);
            }catch(Exception ex)
            {
                return BadRequest("The exception occured is " + ex);
            }
        }

        // GET api/<FlightController>/5
        [HttpGet()]
        [Route("GetById")]
        public IActionResult GetById(string flightnumber)
        {
            try
            {
                var data = from Flight in ac.Flights where Flight.FlightNumber == flightnumber select Flight;
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return BadRequest("The exception ouccured is " + ex);
            }
        }

        /*
 * This is searching flight on basis of 
 * -->One way / Return 
 * -->Departure date
 * -->From to
*/

        [HttpGet]
        [Route("GetOneWay")]
        public IActionResult GetOneWay(string depDate,string arCity,string dpCity)
        {
            try
            {
                var data = from Flight in ac.Flights where (Flight.ArrCity == arCity && Flight.DepCity == dpCity && Flight.TimeOfArr.Date.ToString() == depDate) select Flight;
                if(data!=null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest("The exception ouccured is " + ex);
            }
        }

        






        // POST api/<FlightController>
        [HttpPost]
        [Route("AddFlight")]
        public IActionResult AddFlight([FromBody] Flight value)
        {
            try
            {
                using (ac)
                {
                    if (value != null)
                    {
                        ac.Flights.Add(value);
                        ac.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return NoContent();
                    }
                }
            }catch(Exception ex)
            {
                return BadRequest(ex + " has occured");
            }
        }

        // PUT api/<FlightController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FlightController>/5
        [HttpDelete]
        [Route("DeleteFlight")]
        public IActionResult DeleteFlight(string flightnumber)
        {
            try
            {
                using (ac)
                {
                    Flight f = ac.Flights.Find(flightnumber);
                    if (f == null)
                    {
                        return NotFound($"Flight with {flightnumber} is not present");
                    }
                    else
                    {
                        ac.Flights.Remove(f);
                        ac.SaveChanges();
                        return Ok("Flight deleted successfully");
                    }
                }
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
