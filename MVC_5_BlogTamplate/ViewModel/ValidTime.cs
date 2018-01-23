using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MVC_5_BlogTamplate.ViewModel
{
    public class ValidTime:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dt;
            var isValid =  DateTime.TryParseExact(Convert.ToString(value),
                "HH:mm",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None, out dt);
            return (isValid);
        }
    }
}