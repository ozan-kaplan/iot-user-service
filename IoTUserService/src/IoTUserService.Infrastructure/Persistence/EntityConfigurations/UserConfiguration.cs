using IoTUserService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Infrastructure.Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(d => d.PasswordHash)
                .IsRequired();
            builder.Property(d => d.Status)
                .IsRequired();
        }
    }
}
