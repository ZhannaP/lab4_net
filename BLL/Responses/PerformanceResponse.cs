using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Responses
{
    public class PerformanceResponse
    {
        public int PerformanceID { get; set; }
        public string Name { get; set; } = null!;

        public int Rate { get; set; }

        public string AuthorName { get; set; } = null!;
    }
}
