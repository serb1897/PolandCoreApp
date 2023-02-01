using Microsoft.Extensions.Options;
using PolandDelivery.Models.DBModels;
using PolandDelivery.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PolandDelivery.Interfaces;

namespace PolandDelivery.Models
{
    public class NewsModel : INews
    {
        private IOptions<AppSettings> _appSettings;
        private ApplicationContext _ctx;
        private IDBOperationRepository _dbHelper;

        public NewsModel(IDBOperationRepository dbHelper, ApplicationContext context, IOptions<AppSettings> appSettings)
        {
            _ctx = context;
            _dbHelper = dbHelper;
            _appSettings = appSettings;
        }

        public List<NewsContentSite> GetSliderNews(int topNews) => 
            _ctx.NewsContents.Where(w => !string.IsNullOrEmpty(w.Image) && w.IsPublish == true).OrderByDescending(o => o.CreatedDate).Take(topNews).Select(s => new NewsContentSite(s)).ToList();    

        public List<Banner> GetBanners(int topBanners) =>
            _ctx.Banners.Where(w => w.IsPublish == true).OrderBy(o => o.Sort).Take(topBanners).ToList();

        public NewsResponse GetPageNews(NewsRequest input)
        {
            NewsResponse result = new NewsResponse(input);

            string query = @"select *
                             from NewsContents
                             where (MONTH(CreatedDate) = @month or @month is null)
                             and (YEAR(CreatedDate) = @year or @year is null)
                             and (Title like @search or Content like @search or @search is null)
                             order by CreatedDate desc";
            
            if (!string.IsNullOrEmpty(input.search))
                input.search = $"%{input.search}%";
            result.news = _dbHelper.Query<NewsContent>(query, input).Select(s => new NewsContentSite(s)).ToList();

            if (input.rows == 0)
                result.totalPages = 0;
            else
                result.totalPages = (int)Math.Ceiling((decimal)result.news.Count() / input.rows);
                
            if (input.page > 0)
                result.news = result.news.Skip((input.page - 1) * input.rows).Take(input.rows).ToList();

            result.buttonsLimit = new Dictionary<string, int>();
            int pageFrom = 1;
            int pageTo = _appSettings.Value.newsAtPageNumber;
            if (result.totalPages < pageTo)
            {
                pageTo = result.totalPages;
            }
            else
            {
                if (result.page > _appSettings.Value.newsAtPageNumber - 1)
                {
                    pageTo = result.page + 1;
                    if (result.totalPages < pageTo)
                    {
                        pageTo = result.totalPages;
                    }
                    pageFrom = pageTo - _appSettings.Value.newsAtPageNumber + 1;
                }
            }
            result.buttonsLimit.Add("pageFrom", pageFrom);
            result.buttonsLimit.Add("pageTo", pageTo);

            return result;
        }
    }
}
