using DAL.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Checkout : BaseEntity
    {
        public int TicketStatusId { get; set; }

        public int PerformanceID { get; set; }

        public int AmountOfTickets { get; set; }
        public virtual TicketStatus TicketStatusID { get; set; } = null!;
        public virtual Performance PerformanceId { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
