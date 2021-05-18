using BlueHarvest.Core;
using BlueHarvest.Core.Models;
using BlueHarvest.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueHarvest.Services
{
  
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Transaction> CreateTransaction(Transaction newTransaction)
        {
            newTransaction.Id = Guid.NewGuid();
            await _unitOfWork.Transactions.AddAsync(newTransaction);

            //Update Account Balance
            var account = await _unitOfWork.Accounts.GetByIdAsync(newTransaction.AccountId);
            account.Balance += newTransaction.Amount;
            await _unitOfWork.CommitAsync();

            return newTransaction;
        }
    }
}
