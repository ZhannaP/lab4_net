using DAL.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Ticket : BaseEntity
    {
        public int PerformanceID { get; set; }
        public int CheckoutID { get; set; }
        public int TicketTypeID { get; set; }
        public int SeatNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
