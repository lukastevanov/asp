using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfDataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(e => e.Userid)
                .HasName("roleid");

            builder.Property(e => e.Userid).HasColumnName("userid");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasMaxLength(40);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("password")
                .HasMaxLength(40);

            builder.Property(e => e.Username)
                .IsRequired()
                .HasColumnName("username")
                .HasMaxLength(40);
        }
    }
}
