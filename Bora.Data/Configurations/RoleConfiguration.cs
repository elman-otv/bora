using Bora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bora.Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

        builder.HasData(new List<Role>()
        {
            new Role()
            {
                Id = 1,
                Name = "User"
            },
            new Role()
            {
                Id = 2,
                Name = "Admin"
            }
        });
    }
}