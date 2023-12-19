using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Responses
{
    public class CheckoutResponse
    {
        public int TicketStatusId { get; set; }

        public int PerformanceID { get; set; }

        public int AmountOfTickets { get; set; }

        public decimal Price { get; set; }
    }
}
