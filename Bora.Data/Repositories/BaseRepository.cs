using Bora.Domain.Interfaces.Repositories;

namespace Bora.Data.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>();
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        if(entity == null)
            throw new ArgumentNullException(nameof(entity) + " is null");
        
        await _context.Set<TEntity>().AddAsync(entity);
        
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        if(entity == null)
            throw new ArgumentNullException(nameof(entity) + " is null");
        
        _context.Set<TEntity>().Update(entity);
        
        return entity;
    }

    public void Remove(TEntity entity)
    {
        if(entity == null)
            throw new ArgumentNullException(nameof(entity) + " is null");
        
        _context.Set<TEntity>().Remove(entity);
    }
}