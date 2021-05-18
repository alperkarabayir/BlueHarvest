using BlueHarvest.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueHarvest.Core.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(Guid id);
        Task<Customer> CreateCustomer(Customer newGroup);

        //Other Customer Services Can Be Added Here If Needed
    }
}
