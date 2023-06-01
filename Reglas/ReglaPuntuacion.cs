using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RutasSenderismo.Reglas
{
    internal class ReglaPuntuacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string stringValue)
            {
                if (double.TryParse(stringValue, out double number))
                {
                    if (number >= 0 && number <= 10)
                    {
                        // El número está dentro del rango válido
                        return ValidationResult.ValidResult;
                    }
                }
            }

            // El número está fuera del rango válido o no se pudo convertir
            return new ValidationResult(false, "El número debe estar entre 0 y 10.");
        }
    }
}
