using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dotnet.Blazor.Domain;

namespace Dotnet.Blazor.Infra.Contracts
{
    public interface IApplicationDbContext
    {
        IQueryable<Customer> Customers { get; }
        T Create<T>(T entity) where T : class;
        T Update<T>(T entity) where T : class;
        T Delete<T>(T entity) where T : class;
        Task<int> SaveAsync();
    }
}
