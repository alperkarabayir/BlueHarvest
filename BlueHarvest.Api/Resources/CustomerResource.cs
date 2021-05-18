using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueHarvest.Api.Resources
{
    public class CustomerResource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<AccountResource> Accounts { get; set; }
    }
}
