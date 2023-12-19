using DAL.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class TicketType : BaseEntity
    {
        public string TicketTypeName { get; set; }
    }
}
