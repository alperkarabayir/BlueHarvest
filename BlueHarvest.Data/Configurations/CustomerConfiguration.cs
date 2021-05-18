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
    public class CustomerConfiguration: IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(g => g.Id).HasName("PK_Customer_Id");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(g => g.Id).ValueGeneratedNever();

            builder.Property(e => e.Name).IsRequired();

            builder.Property(e => e.Surname).IsRequired();

            builder.HasMany(g => g.Accounts)
                .WithOne()
                .HasForeignKey(cs => cs.CustomerId)
                .HasConstraintName("FK_Account_Customers_CustomerId");
        }
    }
}
