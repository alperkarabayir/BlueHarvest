using BlueHarvest.Core;
using BlueHarvest.Core.Repositories;
using BlueHarvest.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueHarvest.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlueHarvestDbContext _context;

        public UnitOfWork(BlueHarvestDbContext context)
        {
            this._context = context;
        }

        private CustomerRepository _customerRepository;
        private AccountRepository _accountRepository;
        private TransactionRepository _transactionRepository;

        public ICustomerRepository Customers => _customerRepository = _customerRepository ?? new CustomerRepository(_context);
        public IAccountRepository Accounts => _accountRepository = _accountRepository ?? new AccountRepository(_context);
        public ITransactionRepository Transactions => _transactionRepository = _transactionRepository ?? new TransactionRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
