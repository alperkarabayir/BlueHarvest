using BlueHarvest.Core;
using BlueHarvest.Core.Models;
using BlueHarvest.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueHarvest.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;

        }

        public async Task<Account> CreateAccount(Account newAccount)
        {
            newAccount.Id = Guid.NewGuid();
            //Account Created
            await _unitOfWork.Accounts.AddAsync(newAccount);

            //If initialCredit > 0, a new transaction will be created
            if (newAccount.Balance > 0)
            {
                Transaction newTransaction = new Transaction()
                {
                    Id = Guid.NewGuid(),
                    Amount = newAccount.Balance,
                    AccountId = newAccount.Id
                };

                await _unitOfWork.Transactions.AddAsync(newTransaction);
            }
            
            await _unitOfWork.CommitAsync();

            return newAccount;
        }
    }

}
