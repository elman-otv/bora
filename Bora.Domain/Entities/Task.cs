using Bora.Domain.Interfaces;

namespace Bora.Domain.Entities;

public class Task : IEntityId<long>
{
    public long Id { get; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public TaskStatus Status { get; set; }
    
    public TaskPriority Priority { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? DueDate { get; set; }
    
    public long ProjectId { get; set; }
    
    public long CreatedById { get; set; }
    
    public long? AssignedToId { get; set; }
    
    public Project Project { get; set; }
    
    public User CreatedBy { get; set; }
    
    public User AssignedTo { get; set; }
    
    public ICollection<Comment> Comments { get; set; }
}


public enum TaskStatus
{
    ToDo,
    InProgress,
    Done
}

public enum TaskPriority
{
    Low,
    Medium,
    High
}