using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueHarvest.Core.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public Guid AccountId { get; set; }
    }
}
