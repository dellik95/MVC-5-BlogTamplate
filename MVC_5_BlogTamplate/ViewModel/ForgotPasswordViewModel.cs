using System.ComponentModel.DataAnnotations;

namespace MVC_5_BlogTamplate.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Почта")]
        public string Email { get; set; }
    }
}
