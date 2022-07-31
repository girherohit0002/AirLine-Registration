using Airline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Airline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        AirLineContext ac = new AirLineContext();
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            using (ac)
            {
                return ac.Users.ToList();
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp([FromBody] User value)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ac.Users.Add(value);
                    ac.SaveChanges();
                    return Created("Record Successfully added", value);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            return BadRequest("Something went wrong while saving the record");
        }


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(User.userlogin userlogin)
        {
            string email = userlogin.email;
            string pass = userlogin.pass;
            try
            {
                using (ac)
                {
                    User u = ac.Users.Find(email);
                    if (u == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        if (u.UserPwd == pass)
                        {
                            return Created("Found The User", u);
                        }
                        else
                        {
                            return BadRequest("Invalid creadential");
                        }
                    }
                }
            }catch(Exception ex)
            {
                return null;
            }
        }



        [HttpPut]
        [Route("ResetPassword")]
        public IActionResult Registration(string email,string pass)
        {
            if (email == null)
            {
                return BadRequest("Email cannot be null");
            }
            var data = ac.Users.Where(d => d.EmailId == email).FirstOrDefault();

            if (data == null)
            {
                return NotFound($"User Does not exist");
            }
            
            User ouser = ac.Users.Find(data.EmailId);
            ouser.UserPwd = pass;
            ac.SaveChanges();
            return Ok($"Hey {ouser.FirstName} your password has been updated successfully");

        }


    }
}
