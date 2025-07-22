using Bora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Bora.Domain.Entities.Task;

namespace Bora.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(128);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(128);
        
        builder.HasMany<UserRole>(x  => x.UserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        builder.HasMany<ProjectMember>(x => x.Projects).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        builder.HasMany<Task>(x => x.CreatedTasks).WithOne(x => x.CreatedBy).HasForeignKey(x => x.CreatedById);
        //builder.HasMany<Task>(x => x.CreatedTasks).WithOne(x => x.AssignedTo).HasForeignKey(x => x.AssignedToId);
        builder.HasMany<Comment>(x => x.Comments).WithOne(x => x.User).HasForeignKey(x => x.UserId);

        builder.HasData(new List<User>()
        {
            new User()
            {
                Id = 1,
                UserName = "TestUser",
                Password = "TestUserPassword",
                Email = "testuser@gmail.com",
                FirstName = "TestUserFirstName",
                LastName = "TestUserLastName",
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            }
        });
    }
}