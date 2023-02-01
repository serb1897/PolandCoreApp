using PolandDelivery.Models.DBModels;
using PolandDelivery.Models.ViewModels;
using System.Collections.Generic;

namespace PolandDelivery.Interfaces
{
    public interface INews
    {
        public List<NewsContentSite> GetSliderNews(int topNews);

        public List<Banner> GetBanners(int topBanners);

        public NewsResponse GetPageNews(NewsRequest input);
    }
}
