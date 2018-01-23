using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MVC_5_BlogTamplate.ViewModel
{
    public class FutureDate:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dt;
          var isValid =  DateTime.TryParseExact(Convert.ToString(value),
                "d:dd.mm.yy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None, out dt);
            return (isValid && dt > DateTime.Now);
        }
    }
}