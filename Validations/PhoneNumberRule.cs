using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Restik.Validations
{
    class PhoneNumberRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string phone = (string)value;
            if (!Regex.IsMatch(phone, @"^((\+7)+([0-9]){10})$"))
            {
                return new ValidationResult(false,
                    "Некорректный номер");
            }
            return new ValidationResult(true, null);
        }
    }
}
