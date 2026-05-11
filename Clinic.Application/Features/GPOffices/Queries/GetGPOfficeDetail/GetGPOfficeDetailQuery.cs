using Clinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Application.Features.GPOffices.Queries.GetGPOfficeDetail
{
    public class GetGPOfficeDetailQuery : IRequest<GPOfficeDetailDTO>
    {
        public required Guid Id { get; set; }
    }
     
}
