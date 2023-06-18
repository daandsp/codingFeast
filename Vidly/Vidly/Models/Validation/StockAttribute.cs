using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Models.Validation
{
    public class StockAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie) validationContext.ObjectInstance;

            if (movie.NumberInStock == 0 || movie.NumberInStock > 20)
            {
                return new ValidationResult("Number should be between 1-20");
            }

            return ValidationResult.Success;
        }
    }
}
