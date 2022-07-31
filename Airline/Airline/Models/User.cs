using System;
using System.Collections.Generic;

#nullable disable

namespace Airline.Models
{
    public partial class User

    {
        public class userlogin
        {
            public string email { get; set; }

            public string pass { get; set; }
        }
        public User()
        {
            Tickets = new HashSet<Ticket>();
        }

        public string Mobile { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public string UserPwd { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Userid { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
