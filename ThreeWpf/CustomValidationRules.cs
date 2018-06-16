using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Durczak.AplikacjaWielowarstowa.Core;

namespace ThreeWpf
{
    class CustomValidationRules : ValidationRule
    {

        public ValidationType ValidationType { get; set; }

        public CustomValidationRules() { }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            switch (ValidationType)
            {
                case ValidationType.Integer:
                var result = 0;
                try
                {
                    result = Int32.Parse(((string)value));
                }
                catch (Exception e)
                {
                    return new ValidationResult(false, "Given number is invalid");
                }
              
                return ValidationResult.ValidResult;

                case ValidationType.Material:
                    var material = (string) value;
                    foreach (var val in Enum.GetNames(typeof(Material)))
                    {
                        if(val.Equals(material))
                            return ValidationResult.ValidResult;
                    }

                    return new ValidationResult(false, "Given material type does not exists");              
                    

                case ValidationType.Propulsion:
                    var propulsion = (string)value;
                    foreach (var val in Enum.GetNames(typeof(Propulsion)))
                    {
                        if (val.Equals(propulsion))
                            return ValidationResult.ValidResult;
                    }
                    return new ValidationResult(false, "Given propulsion type does not exists");
               

                case ValidationType.String:
                    return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Unknown value type");

        }
    }

}
