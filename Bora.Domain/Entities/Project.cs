using Bora.Domain.Interfaces;

namespace Bora.Domain.Entities;

public class Project : IEntityId<long>
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public long CreatedById { get; set; }
    
    public User CreatedBy { get; set; }
    
    public ICollection<ProjectMember> Members { get; set; }
    
    public ICollection<Task> Tasks { get; set; }
}