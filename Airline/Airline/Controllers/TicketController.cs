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
        [HttpDelete]
        [Route("TDelete")]
        public IActionResult Deletet(string tickenumber)
        {
            try
            {
                using (ac)
                {
                    Ticket t = ac.Tickets.Find(tickenumber);
                    if (t == null)
                    {
                        return NotFound("Ticket is not found");
                    }
                    ac.Tickets.Remove(t);
                    ac.SaveChanges();
                    return Ok("Ticket has been deleted");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("The exception is " + ex);
            }
        }

        

        // PUT api/<TicketController>/5
        [HttpPost]
        [Route("Book")]    
        public IActionResult BookTicket([FromBody]User u,string flightnumber,string type,int numberOfPessanger)
        {
            try
            {
                Flight f = ac.Flights.Find(flightnumber);
                
                if (type == "buiseness")
                {
                    if(f.SeatsBussiness < numberOfPessanger)
                    {
                        return BadRequest("Seats are not available");
                    }
                    else
                    {
                        Ticket t = new Ticket();
                        t.FlightNumber = flightnumber;
                        t.EmailId = u.EmailId;
                        t.TicketStatus = "Booked";
                        t.DateOfIssue = f.TimeOfArr.Date;
                        f.SeatsBussiness--;

                        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                        var chars2 = "0123456789";
                        var stringChars = new char[12];
                        var random = new Random();

                        for (int i = 0; i < 2; i++)
                        {
                            stringChars[i] = chars[random.Next(chars.Length)];
                        }
                        for (int i = 2; i < stringChars.Length; i++)
                        {
                            stringChars[i] = chars2[random.Next(chars2.Length)];
                        }
                        var finalString = new String(stringChars);

                        t.TicketId = finalString;
                        ac.Tickets.Add(t);
                        ac.SaveChanges();
                        return Ok("Tickek booked successfully");
                    }
                }else
                {
                    if (f.SeatsEco < numberOfPessanger)
                    {
                        return BadRequest("Seats are not available");
                    }
                    else
                    {
                        Ticket t = new Ticket();
                        t.FlightNumber = flightnumber;
                        t.EmailId = u.EmailId;
                        t.TicketStatus = "Booked";
                        t.DateOfIssue = f.TimeOfArr.Date;
                        f.SeatsEco--;

                        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                        var chars2 = "0123456789";
                        var stringChars = new char[12];
                        var random = new Random();

                        for (int i = 0; i < 2; i++)
                        {
                            stringChars[i] = chars[random.Next(chars.Length)];
                        }
                        for (int i = 2; i < stringChars.Length; i++)
                        {
                            stringChars[i] = chars2[random.Next(chars2.Length)];
                        }
                        var finalString = new String(stringChars);

                        t.TicketId = finalString;
                        ac.Tickets.Add(t);
                        ac.SaveChanges();
                        return Ok("Tickek booked successfully");
                    }
                }
            }
            catch(Exception ex)
            {
                return BadRequest("The exception is " + ex);
            }
        }

      

        //// DELETE api/<TicketController>/5
        [HttpPut]
        [Route("Cancelled")]
        public IActionResult CancelTicket(string tickenumber)
        {
            try
            {
                using (ac)
                {
                    Ticket t = ac.Tickets.Find(tickenumber);
                    if (t == null)
                    {
                        return NotFound("Ticket is not found");
                    }
                    t.TicketStatus = "Cancelled";
                    ac.SaveChanges();
                    return Ok("Ticket has been deleted");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("The exception is " + ex);
            }
        }





        [HttpGet]
        [Route("Status")]
        public IActionResult GetStatus(string ticketnumber)
        {
            try
            {
                using (ac)
                {
                    Ticket data = ac.Tickets.Where(t=>t.TicketId==ticketnumber).FirstOrDefault();
                    if (data == null)
                    {
                        return NotFound("Ticket Not Found");
                    }
                    else
                    {
                        return Ok(data.TicketStatus);
                    }
                }
            }catch(Exception ex)
            {
                return BadRequest("The exception is " + ex);
            }
        }
    }
}
