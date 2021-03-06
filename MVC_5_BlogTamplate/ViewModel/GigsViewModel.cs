﻿using System.Collections.Generic;
using MVC_5_BlogTamplate.Models;

namespace MVC_5_BlogTamplate.ViewModel
{
    public class GigsViewModel
    {
        public IEnumerable<Gig> Gigs { get; set; }
        public bool ShowAction { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
    }
}