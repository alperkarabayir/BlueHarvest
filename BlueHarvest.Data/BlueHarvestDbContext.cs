using BlueHarvest.Core.Models;
using BlueHarvest.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlueHarvest.Data
{
    public class BlueHarvestDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public BlueHarvestDbContext(DbContextOptions<BlueHarvestDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new CustomerConfiguration());

            builder
                .ApplyConfiguration(new AccountConfiguration());

            builder
                .ApplyConfiguration(new TransactionConfiguration());
        }
    }
}
