using Microsoft.AspNetCore.Html;
using PolandDelivery.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PolandDelivery.Models.ViewModels
{
    public class NewsResponse : NewsRequest
    {
        public int totalPages { get; set; }
        public List<NewsContentSite> news { get; set; }
        public Dictionary<string, int> buttonsLimit { get; set; }

        public NewsResponse(NewsRequest init) : base(init)
        { }

        public NewsResponse()
        { }
    }

    public class NewsContentSite : NewsContent
    {
        public string ContentShort { 
            get 
            {
                string tmp = string.Empty;
                if (!string.IsNullOrEmpty(this.Content))
                {
                    tmp = StripHTML(this.Content);
                    if (!string.IsNullOrEmpty(tmp))
                    {
                        int tmpLength = tmp.Length > 250 ? 250 : tmp.Length;
                        tmp = tmp.Substring(0, tmpLength);
                    }
                }
                return tmp;
            } 
        }

        public HtmlString ContentHtml
        {
            get
            {
                return new HtmlString(this.Content);
            }
        }

        string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        public NewsContentSite(NewsContent initModel) : base(initModel)
        { }

        public NewsContentSite()
        { }
    }
}
