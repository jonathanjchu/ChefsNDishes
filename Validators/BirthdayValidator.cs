
using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Validators
{
    public class BirthdayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime)
            {
                if ((DateTime)value > DateTime.Now.AddYears(-18))
                {
                    return new ValidationResult("Must be over 18.");
                } 
                else if ((DateTime)value > DateTime.Now)
                {
                    return new ValidationResult("Cannot be a time traveler.");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("Not a valid date");
            }

        }
    }

}