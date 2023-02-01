using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.ViewModels
{
    public class CallbackRequest
    {
        [Required(ErrorMessage = "Вкажіть ім'я")]
        public string name { get; set; }

        [Required(ErrorMessage = "Вкажіть електронну пошту")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Некоректна електронна пошта")]
        public string email { get; set; }

        [Required(ErrorMessage = "Вкажіть телефон")]
        public string phone { get; set; }
        
        public string message { get; set; }
    }
}
