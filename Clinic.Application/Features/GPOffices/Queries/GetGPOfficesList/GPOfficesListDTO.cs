using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Application.Features.GPOffices.Queries.GetGPOfficesList
{
    public class GPOfficesListDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
