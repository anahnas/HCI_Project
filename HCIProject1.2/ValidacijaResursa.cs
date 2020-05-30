using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCIProject1._2
{
    public class ValidacijaResursa : ValidationRule
    {
        public Type ValidationType { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String ime = value as String;
            ime = ime.Trim();
            if(ime.Equals(""))
            {
                return new ValidationResult(false, "Morate unijeti ime");
            } else
            {
                if(ime.Length < 3)
                {
                    return new ValidationResult(false, "Ime mora imati minimalno 3 karaktera");
                }
            }
            return ValidationResult.ValidResult;
        }
    }

    public class ValidacijaOznakeResursa : ValidationRule
    {
        public Type ValidationType { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String oznaka = value as String;
            oznaka = oznaka.Trim();
            if (oznaka.Equals(""))
            {
                return new ValidationResult(false, "Morate unijeti oznaku.");
            }
            else
            {
                if (value.ToString().Length < 3)
                {
                    return new ValidationResult(false, "Oznaka mora imati najmanje 3 karaktera.");
                }
            }
            return ValidationResult.ValidResult;

        }
    }

    public class ValidacijaCijene : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String cijena = value as String;
            cijena = cijena.Trim();

            int n;
            bool isNumeric = int.TryParse(cijena, out n);

            if (!isNumeric)
            {
                return new ValidationResult(false, "Morate unijeti broj.");
            }
            return ValidationResult.ValidResult;
        }
    }


}
