using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Model
{
    public class JRRTable
    {
        public int AutoID { get; set; }
        public string JRName { get; set; }
        public string JJRName { get; set; }
        public DateTime? EndJDTime { get; set; }
        public DateTime? SatJQTime { get; set; }
        public DateTime? SatJHTime { get; set; }
    }
}
