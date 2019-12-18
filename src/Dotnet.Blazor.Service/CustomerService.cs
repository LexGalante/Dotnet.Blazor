using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet.Blazor.Domain;
using Dotnet.Blazor.Infra.Contracts;
using Dotnet.Blazor.Service.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Blazor.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IApplicationDbContext _context;

        public CustomerService(IApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Customer> All() => _context.Customers;

        public async Task<IList<Customer>> AllAsync() => await _context.Customers.ToListAsync();

        public async Task<Customer> CreateAsync(Customer customer)
        {
            _context.Create(customer);
            await _context.SaveAsync();

            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer handler)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == handler.Id);
            if (customer is null)
                throw new Exception("Customer not found");

            customer.Name = handler.Name;
            customer.LastName = handler.LastName;
            customer.Address = handler.Address;

            _context.Create(customer);
            await _context.SaveAsync();

            return customer;
        }

        public async Task<bool> DeleteAsync (int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer is null)
                throw new Exception("Customer not found");

            _context.Delete(customer);
            var rowsAffected = await _context.SaveAsync();

            return rowsAffected > 0;
        }
    }
}
