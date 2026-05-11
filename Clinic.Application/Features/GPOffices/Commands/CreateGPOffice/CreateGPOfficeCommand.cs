using Clinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Application.Features.GPOffices.Commands.CreateGPOffice
{
    public class CreateGPOfficeCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}
