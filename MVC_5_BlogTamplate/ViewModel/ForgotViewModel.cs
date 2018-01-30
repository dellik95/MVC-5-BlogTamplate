using System.ComponentModel.DataAnnotations;

namespace MVC_5_BlogTamplate.ViewModel
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }
    }
}