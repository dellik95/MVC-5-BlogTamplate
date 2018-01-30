using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC_5_BlogTamplate.ViewModel
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<SelectListItem> Providers { get; set; }
    }
}