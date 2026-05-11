using Clinic.Application.Features.GPOffices.Commands.CreateGPOffice;
using Clinic.Application.Features.GPOffices.Queries.GetGPOfficeDetail;
using Clinic.Application.Features.GPOffices.Queries.GetGPOfficesList;
using Clinic.Application.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application
{
    public static class RegisterApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMediator, SimpleMediator>();
             //services.AddScoped<IRequestHandler<GetGPOfficeDetailQuery, GPOfficeDetailDTO>,
            //                            GetGPOfficeDetailQueryHandler>();
            services.AddScoped<IRequestHandler<GetGPOfficeDetailQuery, GPOfficeDetailDTO>, GetGPOfficeDetailQueryHandler>();
                //<IRequestHandler<GetGPOfficeDetailQuery, GPOfficeDetailDTO>, GetGPOfficeDetailQueryHandler>();
            services.AddScoped<IRequestHandler<CreateGPOfficeCommand, Guid>, CreateGPOfficeCommandHandler>();


            services.AddScoped<IRequestHandler<GetGPOfficesListQuery, List<GPOfficesListDTO>>,
                GetGPOfficesListQueryHandler>();


            return services;
        }
    }
}
