using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PolandDelivery.Models;
using PolandDelivery.Models.DBModels;
using PolandDelivery.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Components
{
    public class ServicesCompanyViewComponent : ViewComponent
    {
        private readonly ApplicationContext _databaseContext;
        private readonly IOptions<AppSettings> _appSettings;

        public ServicesCompanyViewComponent(ApplicationContext databaseContext, IOptions<AppSettings> appSettings)
        {
            _databaseContext = databaseContext;
            _appSettings = appSettings;
        }

        public IViewComponentResult Invoke()
        {
            List<ServicesCompanyVCRequest> model = _databaseContext.Menus.Where(w => w.ForServicesBlock == true).Take(_appSettings.Value.bannersNumber).OrderBy(o => o.Sort).Select(s => new ServicesCompanyVCRequest()
            {
                whiteIconUrl = s.WhiteIconUrl,
                blackIconUrl = s.BlackIconUrl,
                name = s.Name,
                url = s.Url
            }).ToList();
            return View(model);
        }
    }
}
