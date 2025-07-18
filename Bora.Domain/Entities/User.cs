using Bora.Domain.Interfaces;

namespace Bora.Domain.Entities;

public class User : IEntityId<long>
{
    public long Id { get; set; }
    
    public string UserName { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public ICollection<UserRole> UserRoles { get; set; }
    
    public ICollection<ProjectMember> Projects { get; set; }
    
    public ICollection<Task> CreatedTasks { get; set; }
    
    public ICollection<Task> AssignedTasks { get; set; }
    
    public ICollection<Comment> Comments { get; set; }
    
}