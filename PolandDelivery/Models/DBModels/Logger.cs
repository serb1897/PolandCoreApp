using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.DBModels
{
    public class Logger
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string LogType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
