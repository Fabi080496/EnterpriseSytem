using EnterpriseSystem.Module.Organization.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnterpriseSystem.Module.Organization.Infraestructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(u => u.Id);
            
            builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
            
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(100);

            builder.Property(u => u.DocumentType).IsRequired().HasMaxLength(4);

            builder.Property(u => u.DocumentNumber).IsRequired().HasMaxLength(50);

            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);

        }
    }
}
