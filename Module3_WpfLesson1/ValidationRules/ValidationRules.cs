using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace Module3_WpfLesson1.ValidationRules
{
    internal class EMailValidationRules : ValidationRule
    {
        public Regex _emailRegex = new Regex(@"^[A-Za-z0-9+_.-]+@[a-z0-9.-]+$");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = value.ToString();
            if (_emailRegex.IsMatch(email)) return new ValidationResult(true, null);
            else return new ValidationResult(false, "Адрес введен не правильно!");

        }
    }

    internal class SmtpValidationRules : ValidationRule
    {
        public Regex _smtpRegex = new Regex(@"^[a-z0-9+_.-]+.[a-z0-9.-]+$");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string smtp = value.ToString();
            if (_smtpRegex.IsMatch(smtp)) return new ValidationResult(true, null);
            else return new ValidationResult(false, "Сервер введен не правильно!");

        }
    }

}
