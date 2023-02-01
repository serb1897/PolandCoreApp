using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.ViewModels
{
    public class NewsRequest
    {
        public int page { get; set; } = 1;
        public int rows { get; set; } = 5;
        public int? month { get; set; }
        public int? year { get; set; }
        public string search { get; set; }

        public NewsRequest(NewsRequest init)
        {
            page = init.page;
            rows = init.rows;
            month = init.month;
            year = init.year;
            search = init.search;
        }

        public NewsRequest()
        { }
    }
}
