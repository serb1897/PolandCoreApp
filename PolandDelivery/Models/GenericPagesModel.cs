using PolandDelivery.Models.ViewModels;
using System.Linq;
using PolandDelivery.Interfaces;

namespace PolandDelivery.Models
{
    public class GenericPagesModel : IGenericPages
    {
        private IDBOperationRepository _dbHelper;

        public GenericPagesModel(IDBOperationRepository dbHelper) => _dbHelper = dbHelper;

        public GenericPagesResponse GetPageContent(int id)
        {
            string query = @"select p.Title as title,
                                    p.HeadImage as headImg,
	                                p.Content as contentTmp,
	                                m.Name as submenu
                            from Pages p
                            left join Menus m on m.Id = p.MenuId
                            where p.IsPublish = 1
                                and p.Id = @id";
            GenericPagesResponse result = _dbHelper.Query<GenericPagesResponse>(query, new { id = id }).FirstOrDefault() ?? new GenericPagesResponse();
            return result;
        }
    }
}
