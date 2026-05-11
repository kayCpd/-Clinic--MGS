using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        Task Commit();
        Task Rollback();
    }
}
