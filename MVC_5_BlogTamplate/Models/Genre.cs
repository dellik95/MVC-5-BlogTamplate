using System.ComponentModel.DataAnnotations;

namespace MVC_5_BlogTamplate.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required] [StringLength(255)] public string Name { get; set; }
    }
}