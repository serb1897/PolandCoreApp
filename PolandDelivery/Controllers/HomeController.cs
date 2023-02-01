using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PolandDelivery.Interfaces;
using PolandDelivery.Models;
using PolandDelivery.Models.DBModels;
using PolandDelivery.Models.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;

namespace PolandDelivery.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<AppSettings> _appSettings;
        private readonly INews _newsModel;
        private readonly IGenericPages _genericPagesModel;

        public HomeController(IOptions<AppSettings> appSettings, INews newsModel, IGenericPages genericPagesModel)
        {
            _appSettings = appSettings;
            _newsModel = newsModel;
            _genericPagesModel = genericPagesModel;
        }

        public IActionResult Index() => View(new HomePageModel()
        {
            news = _newsModel.GetSliderNews(_appSettings.Value.sliderNewsNumber),
            banners = _newsModel.GetBanners(_appSettings.Value.bannersNumber)
        });

        public IActionResult About() => View(_genericPagesModel.GetPageContent(8));

        public IActionResult Contacts() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        public IActionResult Page404() => View();

        public IActionResult NotAccess() => View();
    }
}
