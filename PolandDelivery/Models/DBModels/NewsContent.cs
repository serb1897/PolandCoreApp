using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.DBModels
{
    public class NewsContent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsPublish { get; set; }

        public NewsContent(NewsContent initModel)
        {
            this.Id = initModel.Id;
            this.Title = initModel.Title;
            this.Content = initModel.Content;
            this.Image = initModel.Image;
            this.CreatedDate = initModel.CreatedDate;
            this.IsPublish = initModel.IsPublish;
        }

        public NewsContent()
        { }
    }
}
