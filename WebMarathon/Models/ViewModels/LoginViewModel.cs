using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMarathon.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефону")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

    }
}
