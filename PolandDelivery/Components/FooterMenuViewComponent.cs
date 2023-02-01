using Microsoft.AspNetCore.Mvc;
using PolandDelivery.Interfaces;

namespace PolandDelivery.Components
{
    public class FooterMenuViewComponent : ViewComponent
    {
        private IMenu _model;

        public FooterMenuViewComponent(IMenu model) => _model = model;

        public IViewComponentResult Invoke() => View(_model.GetMenu());
    }
}
