using DAL.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Hole : BaseEntity
    {
        public int TheatreID { get; set; }
        public string Name { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
