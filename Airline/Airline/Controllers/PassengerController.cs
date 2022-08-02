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
    public class PassengerController : ControllerBase
    {
        AirLineContext ac = new AirLineContext();
        // GET: api/<PassengerController>
        [HttpGet]
        public IEnumerable<Passenger> Get()
        {        
                using (ac)
                {
                    return ac.Passengers.ToList();
                }  
        }

        // GET api/<PassengerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PassengerController>
        [HttpPost]
        [Route("AddPassenger")]
        public IActionResult PostAddPassenger([FromBody] Passenger p)
        {
            try
            {
                ac.Passengers.Add(p);
                ac.SaveChanges();
                return Created("Passenger added successfully", p);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetPByTI")]
        public IActionResult getByTid(string ticketnumber)
        {
            try
            {
                using (ac)
                {
                    var data = from p in ac.Passengers where p.TicketId == ticketnumber select p;
                    if (data == null)
                    {
                        return NotFound("No passenger");
                    }
                    return Ok(data);
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
