using PolandDelivery.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.ViewModels
{
    public class HomePageModel
    {
        public List<NewsContentSite> news { get; set; }
        public List<Banner> banners { get; set; }
    }
}
