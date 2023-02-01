using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.DBModels
{
    public class Callback
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public bool? WasAnswer { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
