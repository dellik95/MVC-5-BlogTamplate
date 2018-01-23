﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MVC_5_BlogTamplate.Models;

namespace MVC_5_BlogTamplate.ViewModel
{
    public class GigsFormViewModel
    {
        [Required]
        public string Vanue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse($"{Date} {Time}");
        }
        
    }
}