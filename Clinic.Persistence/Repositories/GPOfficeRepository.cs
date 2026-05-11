using Clinic.Application.Contracts.Repositories;
using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Persistence.Repositories
{
    public class GPOfficeRepository : Repository<GPOffice>, IGPOfficeRepository
    {
        public GPOfficeRepository(ClinicDbContext context)
            : base(context)
        {

        }
    }
}
