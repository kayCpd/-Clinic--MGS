using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Application.Features.GPOffices.Queries.GetGPOfficeDetail
{

    internal static class MapperExtensions
    {
        public static GPOfficeDetailDTO ToDTO(this GPOffice GPOffice)
        {
            var dto = new GPOfficeDetailDTO
            {
                Id = GPOffice.Id,
                Name = GPOffice.Name
            };

            return dto;
        }
    }
}
