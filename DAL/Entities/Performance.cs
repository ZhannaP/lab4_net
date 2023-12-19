using DAL.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Performance : BaseEntity
    {
        public string Name { get; set; } = null!;
        public virtual  Hall HoleID { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int Rate { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Checkout> Checkouts { get; set; } = new List<Checkout>();
    }
}
