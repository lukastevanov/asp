using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfDataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasIndex(e => e.CustomerId)
                .HasName("IndexOrderCustomerId");

            builder.HasIndex(e => e.OrderDate)
                .HasName("IndexOrderOrderDate");

            builder.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.OrderNumber).HasMaxLength(10);

            builder.Property(e => e.TotalAmount)
                .HasColumnType("decimal(12, 2)")
                .HasDefaultValueSql("((0))");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Order)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDER_REFERENCE_CUSTOMER");
        }
    }
}
