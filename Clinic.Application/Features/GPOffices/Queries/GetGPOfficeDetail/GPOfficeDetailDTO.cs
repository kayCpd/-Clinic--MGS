using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Application.Features.GPOffices.Queries.GetGPOfficeDetail
{
    public class GPOfficeDetailDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
