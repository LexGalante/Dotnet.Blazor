using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dotnet.Blazor.Domain;

namespace Dotnet.Blazor.Service.Contracts
{
    public interface ICustomerService
    {
        IQueryable<Customer> All();
        Task<IList<Customer>> AllAsync();
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer handler);
        Task<bool> DeleteAsync(int id);
    }
}
