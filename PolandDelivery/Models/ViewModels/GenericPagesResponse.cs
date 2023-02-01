using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.ViewModels
{
    public class GenericPagesResponse
    {
        public string title { get; set; }
        public string submenu { get; set; }
        public string headImg { get; set; }
        public string contentTmp { get; set; }
        public HtmlString content {
            get
            {
                return new HtmlString(this.contentTmp);
            }
        }
    }
}
