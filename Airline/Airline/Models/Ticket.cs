using System;
using System.Collections.Generic;

#nullable disable

namespace Airline.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            Passengers = new HashSet<Passenger>();
        }

        public string TicketId { get; set; }
        public string TicketStatus { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string EmailId { get; set; }
        public string FlightNumber { get; set; }

        public virtual User Email { get; set; }
        public virtual Flight FlightNumberNavigation { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
