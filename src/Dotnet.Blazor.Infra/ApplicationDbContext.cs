using System;
using System.Linq;
using System.Threading.Tasks;
using Dotnet.Blazor.Domain;
using Dotnet.Blazor.Infra.Configurations;
using Dotnet.Blazor.Infra.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Blazor.Infra
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfiguration());
        }

        public IQueryable<Customer> Customers => Set<Customer>();

        public T Create<T>(T entity) where T : class => base.Add(entity).Entity;

        public T Update<T>(T entity) where T : class => base.Update(entity).Entity;

        public T Delete<T>(T entity) where T : class => base.Remove(entity).Entity;

        public async Task<int> SaveAsync() => await base.SaveChangesAsync();
    }
}
