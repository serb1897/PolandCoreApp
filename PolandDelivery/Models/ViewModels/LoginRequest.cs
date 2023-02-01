using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.ViewModels
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Введіть логін")]
        [Display(Name = "Логін")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string password { get; set; }

        [Display(Name = "Запам'ятати?")]
        public bool rememberMe { get; set; }

        public string returnUrl { get; set; }
    }
}
