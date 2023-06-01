using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RutasSenderismo.Reglas
{
    internal class ReglaCampoNoVacio: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!String.IsNullOrEmpty((string)value))
            {
                return new ValidationResult(true, "hello");
            }
            return new ValidationResult(false, "Campo obligatorio");
        }
    }
}
