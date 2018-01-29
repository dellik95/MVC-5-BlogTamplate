using System;

namespace MVC_5_BlogTamplate.Dto
{
    public class GigDto
    {
        public int Id { get; set; }

        public UserDto Artist { get; set; }

        public bool IsCanceled { get;  set; }

        public DateTime DateTime { get; set; }

        public string Vanue { get; set; }

        public GenreDto Genre { get; set; }


    }
}