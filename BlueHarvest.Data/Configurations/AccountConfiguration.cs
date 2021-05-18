using BlueHarvest.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueHarvest.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");

            builder.HasKey(g => g.Id).HasName("PK_Account_Id");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(g => g.Id).ValueGeneratedNever();

            builder.Property(g => g.Balance).IsRequired().HasColumnType("decimal(9,2)");

            builder.HasMany(g => g.Transactions)
                .WithOne()
                .HasForeignKey(cs => cs.AccountId)
                .HasConstraintName("FK_Transaction_Accounts_AccountId");
        }
    }
}
