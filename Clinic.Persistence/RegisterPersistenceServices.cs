using Clinic.Application.Contracts.Persistence;
using Clinic.Application.Contracts.Repositories;
using Clinic.Persistence.Repositories;
using Clinic.Persistence.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Persistence
{
    public static class RegisterPersistenceServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ClinicDbContext>(options =>
                options.UseSqlServer("name=ClinicConnectionString"));

            services.AddScoped<IGPOfficeRepository, GPOfficeRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWorkEFCore>();

            return services;
        }
    }
}
