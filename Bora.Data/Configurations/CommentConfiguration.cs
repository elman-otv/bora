using Bora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bora.Data.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Text).IsRequired().HasMaxLength(512);
        
        builder.HasOne(x => x.Task).WithMany().HasForeignKey(x => x.TaskId);
        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);

        builder.HasData(new List<Comment>()
        {
            new Comment()
            {
                Id = 1,
                Text = "Comment #1 from User #1 in Task #1",
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                TaskId = 1,
                UserId = 1
            }
        });
    }
}