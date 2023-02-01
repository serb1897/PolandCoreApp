using PolandDelivery.Models.ViewModels;

namespace PolandDelivery.Interfaces
{
    public interface IGenericPages
    {
        public GenericPagesResponse GetPageContent(int id);
    }
}
