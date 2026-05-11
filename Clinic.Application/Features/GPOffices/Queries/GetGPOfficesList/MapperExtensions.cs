using Clinic.Application.Features.GPOffices.Queries.GetGPOfficesList;
using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Application.Features.GPOffices.Queries.GetGPOfficesList
{
    internal static class MapperExtensions
    {
        public static GPOfficesListDTO ToDTO(this GPOffice GPOffice)
        {
            var dto = new GPOfficesListDTO
            {
                Id = GPOffice.Id,
                Name = GPOffice.Name
            };
            return dto;
        }

    }
}
