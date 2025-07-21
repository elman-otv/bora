using Bora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Bora.Domain.Entities.Task;
using TaskStatus = Bora.Domain.Entities.TaskStatus;

namespace Bora.Data.Configurations;

public class TaskConfiguration :  IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(64);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(256);
        builder.Property(x => x.Priority).IsRequired();
        
        builder.HasOne(x => x.Project).WithMany(p => p.Tasks).HasForeignKey(x => x.ProjectId);
        builder.HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById);
        builder.HasOne(x => x.AssignedTo).WithMany().HasForeignKey(x => x.AssignedToId);
        builder.HasMany(x => x.Comments).WithOne(x => x.Task).HasForeignKey(x => x.TaskId);
        
        builder.HasData(new
        {
            Id = 1L,
            Title = "Test Task",
            Description = "Test Task Description",
            Status = TaskStatus.InProgress,
            Priority = TaskPriority.High,
            CreatedAt = DateTime.UtcNow,
            DueDate = DateTime.UtcNow.AddDays(7),
            ProjectId = 1L,
            CreatedById = 1L
        });
    }
}