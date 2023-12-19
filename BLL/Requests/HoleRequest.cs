using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Requests
{
    public class HoleRequest
    {
        public int HoleId { get; set; }
        public int TheatreId { get; set; }
        public string Name { get; set; } = null!;
        public int NumberOfSeats { get; set; }
    }
}
