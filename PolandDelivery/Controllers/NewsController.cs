using Microsoft.AspNetCore.Mvc;
using PolandDelivery.Interfaces;
using PolandDelivery.Models.ViewModels;

namespace PolandDelivery.Controllers
{
    public class NewsController : Controller
    {
        private readonly INews _model;

        public NewsController(INews model) => _model = model;

        public IActionResult Index(NewsRequest input) => View(_model.GetPageNews(input));
    }
}
