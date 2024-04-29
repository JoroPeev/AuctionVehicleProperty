using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionVehicleProperty.Core.Extensions
{
    public class NonNegativeRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(ErrorMessage ?? "The field is required.");
            }

            // Check if the value is numeric and less than 0
            if (IsNumeric(value) && (int)value < 0)
            {
                return new ValidationResult(ErrorMessage ?? "Please enter a non-negative value.");
            }

            return ValidationResult.Success;
        }

        // Method to check if a value is numeric
        private bool IsNumeric(object value)
        {
            return value is int || value is long || value is decimal || value is float || value is double;
        }
    }
}
