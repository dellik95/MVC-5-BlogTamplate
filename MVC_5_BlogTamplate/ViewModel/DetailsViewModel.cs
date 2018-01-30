using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_5_BlogTamplate.Models;

namespace MVC_5_BlogTamplate.ViewModel
{
    public class DetailsViewModel
    {

        public Gig Gig { get; set; }
        public bool IsFollow { get; set; }
        public bool IsAttenting { get; set; }
        public bool IsAuthonticated { get; set; }
    }
}