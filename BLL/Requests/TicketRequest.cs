using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Requests
{
    public class TicketRequest
    {
        public int Id { get; set; }

        public int CheckoutId { get; set; }

        public int PerformanceId { get; set; }

        public string Performance { get; set; }

        public string Type { get; set; } 

        public string Description { get; set; }
        public string Status { get; set; }

        public int Price { get; set; }

        public int SeatNumber { get; set; }
    }
}
