using System.ComponentModel.DataAnnotations;

namespace MVC_5_BlogTamplate.Models
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Номер телефона")]
        public string Number { get; set; }
    }
}