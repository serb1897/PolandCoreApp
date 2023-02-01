using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.ViewModels
{
    public class ApiResult
    {
        public bool state { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public ApiResult()
        { }

        public ApiResult(string _message)
        {
            message = _message;
            state = string.IsNullOrEmpty(message);
        }

        public ApiResult (IEnumerable<Microsoft.AspNetCore.Mvc.ModelBinding.ModelError> errors)
        {
            if (errors.Count() > 0)
                message = errors.ElementAt(0).ErrorMessage;
            else
                message = string.Empty;
            state = string.IsNullOrEmpty(message);
        }
    }
}
