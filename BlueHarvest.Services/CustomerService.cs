using BlueHarvest.Core;
using BlueHarvest.Core.Models;
using BlueHarvest.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueHarvest.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            
        }
        public async Task<Customer> CreateCustomer(Customer newCustomer)
        {
            newCustomer.Id = Guid.NewGuid();
            await _unitOfWork.Customers.AddAsync(newCustomer);
            await _unitOfWork.CommitAsync();
            return newCustomer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = await _unitOfWork.Customers.GetAllCustomersAsync();
            if (customers != null)
            {
                return customers;
            }
            throw new Exception("Customers can not found");
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            var customer = await _unitOfWork.Customers.GetCustomerByIdAsync(id);
            if (customer != null)
            {
                return customer;
            }
            throw new Exception("Customer can not found");
        }
    }
}
