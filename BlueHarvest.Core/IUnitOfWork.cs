using BlueHarvest.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace BlueHarvest.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        ICustomerRepository Customers { get; }
        ITransactionRepository Transactions { get; }

        Task<int> CommitAsync();
    }
}
