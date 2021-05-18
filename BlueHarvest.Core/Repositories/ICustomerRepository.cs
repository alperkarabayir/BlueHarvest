using BlueHarvest.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueHarvest.Core.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(Guid id);
        //Add Customer Based Repository Operation Methods Here
        //Empty Because Just Basic Operation Methods Enough - IRepository 
    }
}
