using BlueHarvest.Core.Models;
using BlueHarvest.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueHarvest.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(BlueHarvestDbContext context)
            : base(context)
        { }
        
        // BlueHarvest.Core.Repository Getting Repository From Here
        // Other DB Operations Can Be Added Here
    }
}
