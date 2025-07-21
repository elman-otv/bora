using Bora.Domain.Interfaces;

namespace Bora.Domain.Entities;

public class Comment : IEntityId<long>
{
    public long Id { get; set; }
    
    public string Text { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public long TaskId { get; set; }
    
    public long UserId { get; set; }
    
    public Task Task { get; set; }
    
    public User User { get; set; }
}