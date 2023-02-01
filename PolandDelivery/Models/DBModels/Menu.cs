using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.DBModels
{
    public class Menu
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? Sort { get; set; }
        public string WhiteIconUrl { get; set; }
        public string BlackIconUrl { get; set; }
        public bool? ForServicesBlock { get; set; }
    }
}
