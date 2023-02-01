using PolandDelivery.Models.ViewModels;

namespace PolandDelivery.Interfaces
{
    public interface IUserForms
    {
        public ApiResult SendCallbackRequest(CallbackRequest input);

        public ApiResult SendMailingRequest(MailingRequest input);
    }
}
