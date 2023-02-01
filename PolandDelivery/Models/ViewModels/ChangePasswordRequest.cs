using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.ViewModels
{
    public class ChangePasswordRequest
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string newPassword { get; set; }
    }
}
