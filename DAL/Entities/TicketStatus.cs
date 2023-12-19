using DAL.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class TicketStatus : BaseEntity
    {
        public string StatusName { get; set; } = null!;
        public virtual ICollection<Checkout> Checkouts { get; set; } = new List<Checkout>();

    }
}
