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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");

            builder.HasKey(g => g.Id).HasName("PK_Transaction_Id");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(g => g.Id).ValueGeneratedNever();

            builder.Property(g => g.Amount).IsRequired().HasColumnType("decimal(9,2)");

        }
    }
}
