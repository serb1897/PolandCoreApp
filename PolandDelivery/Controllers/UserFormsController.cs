using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolandDelivery.Interfaces;
using PolandDelivery.Models.ViewModels;
using System.Linq;

namespace PolandDelivery.Controllers
{
    public class UserFormsController : Controller
    {
        private readonly IUserForms _model;
        private readonly ILogger<UserFormsController> _logger;

        public UserFormsController(ILogger<UserFormsController> logger, IUserForms model)
        {
            _model = model;
            _logger = logger;
        }

        [HttpPost]
        public JsonResult SendCallbackRequest(CallbackRequest input)
        {
            ApiResult result;
            if (ModelState.IsValid)
            {
                result = _model.SendCallbackRequest(input);
            }
            else
            {
                result = new ApiResult(ModelState.Values.SelectMany(v => v.Errors));
                _logger.LogError(result.message);
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult SendMailingRequest(MailingRequest input)
        {
            ApiResult result;
            if (ModelState.IsValid)
            {
                result = _model.SendMailingRequest(input);
            }
            else
            {
                result = new ApiResult(ModelState.Values.SelectMany(v => v.Errors));
                _logger.LogError(result.message);
            }
            return Json(result);
        }
    }
}
