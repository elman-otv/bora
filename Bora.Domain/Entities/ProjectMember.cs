namespace Bora.Domain.Entities;

public class ProjectMember
{
    public long ProjectId { get; set; }
    
    public long UserId { get; set; }
    
    public Project Project { get; set; }
    
    public User User { get; set; }
}