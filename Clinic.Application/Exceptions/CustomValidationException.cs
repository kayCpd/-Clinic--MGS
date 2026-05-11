using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;

namespace Clinic.Application.Exceptions
{
   public class CustomValidationException : Exception
    {
        public List<string> ValidationErrors { get; set; } = new List<string>();
       
        public CustomValidationException(ValidationResult validationResult)
        {
            foreach (var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }
        }

    }
}
