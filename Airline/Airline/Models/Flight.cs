using System;
using System.Collections.Generic;

#nullable disable

namespace Airline.Models
{
    public partial class Flight
    {
        public Flight()
        {
            Tickets = new HashSet<Ticket>();
        }

        public string FlightNumber { get; set; }
        public string TimeOfArr { get; set; }
        public string Duration { get; set; }
        public int PriceEco { get; set; }
        public int PriceBn { get; set; }
        public string DepCity { get; set; }
        public string ArrCity { get; set; }
        public string TimeOfDept { get; set; }
        public int SeatsEco { get; set; }
        public int SeatsBussiness { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
