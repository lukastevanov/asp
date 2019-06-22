using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfDataAccess.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasIndex(e => new { e.LastName, e.FirstName })
                .HasName("IndexCustomerName");

            builder.Property(e => e.City).HasMaxLength(40);

            builder.Property(e => e.Country).HasMaxLength(40);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.Phone).HasMaxLength(20);
        }
    }
}
