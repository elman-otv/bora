using Bora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bora.Data.Configurations;

public class ProjectMemberConfiguration : IEntityTypeConfiguration<ProjectMember>
{
    public void Configure(EntityTypeBuilder<ProjectMember> builder)
    {
        builder.HasKey(pm => new {pm.ProjectId, pm.UserId});
        
        builder.HasData(new List<ProjectMember>()
        {
            new  ProjectMember()
            {
                ProjectId = 1,
                UserId = 1
            }
        });
    }
}