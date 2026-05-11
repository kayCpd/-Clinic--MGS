using Clinic.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Persistence.UnitsOfWork
{
    public class UnitOfWorkEFCore : IUnitOfWork
    {
        private readonly ClinicDbContext context;

        public UnitOfWorkEFCore(ClinicDbContext context)
        {
            this.context = context;
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
