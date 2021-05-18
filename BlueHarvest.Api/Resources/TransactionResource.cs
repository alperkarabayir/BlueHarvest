using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueHarvest.Api.Resources
{
    public class TransactionResource
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
    }
}
