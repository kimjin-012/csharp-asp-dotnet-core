using System;
using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner
{
    public class BirthDayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime? date = (DateTime?)value;
            if(date < DateTime.Now)
                return new ValidationResult("It has to be in the future...");
            return ValidationResult.Success;
        }
    }
}