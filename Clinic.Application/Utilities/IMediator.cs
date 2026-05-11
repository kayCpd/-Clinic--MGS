using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Application.Utilities
{
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}
