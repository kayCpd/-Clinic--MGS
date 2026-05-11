using Clinic.Application.Contracts.Repositories;
using Clinic.Application.Exceptions;
using Clinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.GPOffices.Queries.GetGPOfficeDetail
{
    public class GetGPOfficeDetailQueryHandler : IRequestHandler<GetGPOfficeDetailQuery, GPOfficeDetailDTO >
    {
        private readonly IGPOfficeRepository repository;

        public GetGPOfficeDetailQueryHandler(IGPOfficeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GPOfficeDetailDTO> Handle(GetGPOfficeDetailQuery request)
        {
            var GPOffice = await repository.GetById(request.Id);

            if (GPOffice is null)
            {
                throw new NotFoundException($"GPOffice with Id '{request.Id}' was not found.");
            }

            return GPOffice.ToDTO();
        }
    }
}
