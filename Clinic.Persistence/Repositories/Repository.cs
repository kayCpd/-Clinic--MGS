using Clinic.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ClinicDbContext context;

        public Repository(ClinicDbContext context)
        {
            this.context = context;
        }

        public Task<T> Add(T entity)
        {
            context.Add(entity);
            return Task.FromResult(entity);
        }

        public Task Delete(T entity)
        {
            context.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public Task Update(T entity)
        {
            context.Update(entity);
            return Task.CompletedTask;
        }
    }
}
