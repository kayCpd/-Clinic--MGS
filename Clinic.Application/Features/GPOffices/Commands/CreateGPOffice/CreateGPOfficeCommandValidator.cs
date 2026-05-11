using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FluentValidation; 

namespace Clinic.Application.Features.GPOffices.Commands.CreateGPOffice
{
    public class CreateGPOfficeCommandValidator : AbstractValidator<CreateGPOfficeCommand>
    {
        public CreateGPOfficeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The field {PropertyName} is required");
        }
    }
}
