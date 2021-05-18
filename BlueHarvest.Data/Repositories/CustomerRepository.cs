using BlueHarvest.Core.Models;
using BlueHarvest.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueHarvest.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BlueHarvestDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await BlueHarvestDbContext.Customers
                .Include(a => a.Accounts)
                .ThenInclude(b => b.Transactions)
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            return await BlueHarvestDbContext.Customers
                .Include(a => a.Accounts)
                .ThenInclude(b => b.Transactions)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private BlueHarvestDbContext BlueHarvestDbContext
        {
            get { return Context as BlueHarvestDbContext; }
        }

        // BlueHarvest.Core.Repository Getting Repository From Here
        // Other DB Operations Can Be Added Here
    }
}
