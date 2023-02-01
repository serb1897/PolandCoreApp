using PolandDelivery.Models.DBModels;
using System.Collections.Generic;

namespace PolandDelivery.Interfaces
{
    public interface IMenu
    {
        public List<Menu> GetMenu();
    }
}
