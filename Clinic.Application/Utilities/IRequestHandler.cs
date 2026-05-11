using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Application.Utilities
{
    public interface IRequestHandler<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
