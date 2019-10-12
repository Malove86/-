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
        public DateTime? EndJDTime { get; set; }
        public DateTime? intSatJQTime { get; set; }
        public DateTime? SatJHTime { get; set; }
    }
}
