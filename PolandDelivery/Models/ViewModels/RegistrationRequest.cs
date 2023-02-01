using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.ViewModels
{
    public class RegistrationRequest
    {
        [Required(ErrorMessage = "Введіть логін")]
        [Display(Name = "Логін")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string password { get; set; }

        [Required(ErrorMessage = "Введіть підтвердження пароля")]
        [Compare("password", ErrorMessage = "Паролі не співпадають")]
        [DataType(DataType.Password)]
        [Display(Name = "Підтвердити пароль")]
        public string passwordConfirm { get; set; }
    }
}
