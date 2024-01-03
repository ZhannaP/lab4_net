using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Responses
{
    public class HoleResponse
    {
        public int HoleId { get; set; }
        public string Name { get; set; } = null!;
        public int NumberOfSeats { get; set; }
    }
}
