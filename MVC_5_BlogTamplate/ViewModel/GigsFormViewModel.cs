using System.Collections.Generic;
using MVC_5_BlogTamplate.Models;

namespace MVC_5_BlogTamplate.ViewModel
{
    public class GigsFormViewModel
    {
        public string Vanue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}