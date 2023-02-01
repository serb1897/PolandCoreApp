using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PolandDelivery.Interfaces;
using PolandDelivery.Models;
using PolandDelivery.Models.DBModels;
using PolandDelivery.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Components
{
    public class HeaderMenuViewComponent : ViewComponent
    {
        private IMenu _model;
        
        public HeaderMenuViewComponent(IMenu model) => _model = model;

        public IViewComponentResult Invoke() => View(_model.GetMenu());
    }
}
