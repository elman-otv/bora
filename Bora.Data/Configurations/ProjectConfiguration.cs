using Bora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Bora.Domain.Entities.Task;

namespace Bora.Data.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(1000);

        builder.HasOne<User>(p => p.CreatedBy).WithMany().HasForeignKey(p => p.CreatedById);
        builder.HasMany<ProjectMember>(p => p.Members).WithOne(p => p.Project).HasForeignKey(p => p.ProjectId);
        builder.HasMany<Task>(p => p.Tasks).WithOne(p => p.Project).HasForeignKey(p => p.ProjectId);
        
        builder.HasData(new List<Project>()
        {
            new Project()
            {
                Id = 1,
                Name = "Project Test 1",
                Description = "This is a test project",
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                CreatedById = 1
            }
        });
    }
}