using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Models.Validation
{
    public class MovieDateAddedAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            var currentDate = DateTime.Today.Date;

            return (movie.DateAdded.Date == currentDate) 
                ? ValidationResult.Success 
                : new ValidationResult("Date has to be today's date.");



        }
    }
}
