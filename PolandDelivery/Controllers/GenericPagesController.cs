using Microsoft.AspNetCore.Mvc;
using PolandDelivery.Interfaces;

namespace PolandDelivery.Controllers
{
    public class GenericPagesController : Controller
    {
        private readonly IGenericPages _model;

        public GenericPagesController(IGenericPages model) => _model = model;

        public IActionResult Index(int id) => View(_model.GetPageContent(id));
    }
}
