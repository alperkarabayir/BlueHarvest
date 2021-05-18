using BlueHarvest.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueHarvest.Core.Services
{
    public interface ITransactionService
    {
        Task<Transaction> CreateTransaction(Transaction newTransaction);

        //Other Transaction Services Can Be Added Here If Needed
    }
}
