using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.DBModels
{
    public class Banner
    {
        public int Id { get; set; }
        public string HeadImage { get; set; }
        public string HeadImageMobile { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Sort { get; set; }
        public bool? IsPublish { get; set; }
    }
}
