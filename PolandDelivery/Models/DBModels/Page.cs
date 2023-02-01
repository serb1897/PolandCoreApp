using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.DBModels
{
    public class Page
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? MenuId { get; set; }
        public string HeadImage { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsPublish { get; set; }
    }
}
