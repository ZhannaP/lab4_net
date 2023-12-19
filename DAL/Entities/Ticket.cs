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
        public virtual Performance PerformanceID { get; set; } = null!;
        public virtual Checkout CheckoutID { get; set; } = null!;
        public virtual TicketType TicketTypeID { get; set; } = null!;
        public int SeatNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
