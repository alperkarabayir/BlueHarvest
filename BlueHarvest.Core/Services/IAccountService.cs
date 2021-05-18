using BlueHarvest.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueHarvest.Core.Services
{
    public interface IAccountService
    {
        Task<Account> CreateAccount(Account newAccount);

        //Other Account Services Can Be Added Here If Needed
    }
}
