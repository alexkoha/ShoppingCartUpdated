using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ShoppingCart.WPF.Users
{
    class UsernameValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (String.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(false, "Cannot be empty");
            }
            if (value.ToString().Length > 20)
            {
                return new ValidationResult(false, "Cannot be lonegr then 20 ");
            }
            return ValidationResult.ValidResult;
        }
    }
}