using System.ComponentModel.DataAnnotations;

namespace MVC_5_BlogTamplate.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }
    }
}