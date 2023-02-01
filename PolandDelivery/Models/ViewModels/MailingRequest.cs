using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.ViewModels
{
    public class MailingRequest
    {
        [Required(ErrorMessage = "Вкажіть електронну пошту")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Некоректна електронна пошта")]
        public string email { get; set; }
    }
}
