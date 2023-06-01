using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RutasSenderismo.Reglas
{
    internal class ReglaTelefono : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int longitud = ((string)value).Length;
            bool result = true;
            if ((longitud == 9))
            {
                for (var i = 0; i < longitud && result == true; i++)
                {
                    if (Char.IsDigit(((string)value)[i]) == false)
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            if (result)
                return new ValidationResult(true, null);
            return new ValidationResult(false, "9 dígitos");
        }
    }
}
