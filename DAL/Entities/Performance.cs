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
        public virtual  Hole HoleID { get; set; } = null!;
        public string Author { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; }
    }
}
