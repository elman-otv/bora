using Bora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bora.Data.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(pm => new {pm.UserId, pm.RoleId});
        
        builder.HasData(new List<UserRole>()
        {
            new UserRole()
            {
                UserId = 1,
                RoleId = 1
            }
        });
    }
}