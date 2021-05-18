using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueHarvest.Core.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public decimal Balance { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public Guid CustomerId { get; set; }
    }
}
