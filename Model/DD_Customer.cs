using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Model
{
    public class DD_Customer
    {
        public int AutoId { get; set; }
        public string XS_BMNum { get; set; }
        public string XS_KHNum { get; set; }
        public DateTime? DD_RQTime { get; set; }
        public DateTime? DD_QRTime { get; set; }
        public DateTime? DD_ZDTime { get; set; }
        public DateTime? DD_SDTime { get; set; }
        public DateTime? DD_CZTime{ get; set; }
        public string DD_HS { get; set; }       
    }
}
