using Clinic.Application.Contracts.Repositories;
using Clinic.Application.Features.GPOffices.Queries.GetGPOfficeDetail;
using Clinic.Application.Features.GPOffices.Queries.GetGPOfficesList;
using Clinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Application.Features.GPOffices.Queries.GetGPOfficesList
{
    public class GetGPOfficesListQueryHandler 
        : IRequestHandler<GetGPOfficesListQuery, List<GPOfficesListDTO>>
    {
        private readonly IGPOfficeRepository repository;

        public GetGPOfficesListQueryHandler(IGPOfficeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<GPOfficesListDTO>> Handle(GetGPOfficesListQuery request)
        {
            var GPOffices = await repository.GetAll();
            var GPOfficesDTO = GPOffices.Select(GPOffice => GPOffice.ToDTO()).ToList();
        
            return GPOfficesDTO;   
        }
    }   
}
