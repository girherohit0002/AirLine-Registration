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
    public class TicketController : ControllerBase
    {
        AirLineContext ac = new AirLineContext();
        // GET: api/<TicketController>
        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            using (ac)
            {
                return ac.Tickets.ToList();
            }
        }



        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }





        [HttpGet]
        [Route("Status")]
        public IActionResult GetStatus([FromBody] string ticketnumber)
        {
            try
            {
                using (ac)
                {
                    Ticket ticket = ac.Tickets.Find(ticketnumber);
                    if (ticket == null)
                    {
                        return NotFound("Ticket Not Found");
                    }
                    else
                    {
                        return Ok(ticket.TicketStatus);
                    }
                }
            }catch(Exception ex)
            {
                return BadRequest("The exception is " + ex);
            }
        }
    }
}
