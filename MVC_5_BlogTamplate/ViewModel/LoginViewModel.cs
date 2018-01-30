﻿using System.ComponentModel.DataAnnotations;

namespace MVC_5_BlogTamplate.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Адрес электронной почты")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")] public bool RememberMe { get; set; }
    }
}