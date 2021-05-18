using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueHarvest.Api.Resources
{
    public class AccountResource
    {
        public Guid Id { get; set; }
        public decimal Balance { get; set; }
        public ICollection<TransactionResource> Transactions { get; set; }
    }
}
