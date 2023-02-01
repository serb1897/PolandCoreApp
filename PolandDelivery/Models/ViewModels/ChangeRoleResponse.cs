using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.ViewModels
{
    public class ChangeRoleResponse
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public List<IdentityRole> allRoles { get; set; }
        public IList<string> userRoles { get; set; }
        public ChangeRoleResponse()
        {
            allRoles = new List<IdentityRole>();
            userRoles = new List<string>();
        }
    }
}
