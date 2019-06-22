using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfDataAccess.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(e => e.Roleid).HasColumnName("roleid");

            builder.Property(e => e.Admin)
                .IsRequired()
                .HasColumnName("admin")
                .HasMaxLength(40);

            builder.Property(e => e.Username)
                .IsRequired()
                .HasColumnName("username")
                .HasMaxLength(40);
        }
    }
}
