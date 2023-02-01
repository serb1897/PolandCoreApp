using PolandDelivery.Models.DBModels;
using System.Collections.Generic;
using System.Linq;
using PolandDelivery.Interfaces;

namespace PolandDelivery.Models
{
    public class MenuModel : IMenu
    {
        private IDBOperationRepository _dbHelper;

        public MenuModel(IDBOperationRepository dbHelper) => _dbHelper = dbHelper;
        
        public List<Menu> GetMenu() => _dbHelper.Query<Menu>("select * from Menus", null).ToList();   
    }
}
