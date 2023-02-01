using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models
{
    public class AppSettings
    {
        public string connectionString { get; set; }
        public int sliderNewsNumber { get; set; }
        public int newsAtPageNumber { get; set; }
        public int bannersNumber { get; set; }
        public string logPath { get; set; }
        public bool initDB { get; set; }
    }
}
