using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfDataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(e => e.ProductName)
                .HasName("IndexProductName");

            builder.HasIndex(e => e.SupplierId)
                .HasName("IndexProductSupplierId");

            builder.Property(e => e.Package).HasMaxLength(30);

            builder.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.UnitPrice)
                .HasColumnType("decimal(12, 2)")
                .HasDefaultValueSql("((0))");

            builder.HasOne(d => d.Supplier)
                .WithMany(p => p.Product)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCT_REFERENCE_SUPPLIER");
        }
    }
}
