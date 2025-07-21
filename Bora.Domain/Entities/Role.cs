using Bora.Domain.Interfaces;

namespace Bora.Domain.Entities;

public class Role : IEntityId<long>
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<UserRole> UserRoles { get; set; }
}