﻿using DAL.Base;

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
        public int PerformaceId { get; set; } 
        public int SeatNumber { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Price {  get; set; }
    }
}
