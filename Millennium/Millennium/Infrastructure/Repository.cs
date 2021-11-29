using System.Collections;
using Millennium.Infrastructure;
using Millennium.Models;
public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected List<TEntity> inMemoryDatabase;
    protected readonly ILogger<TEntity> logger;

    public Repository(ILogger<TEntity> logger)
    {
        this.logger = logger;
        this.inMemoryDatabase = new List<TEntity>();
    }

    public TEntity Add(TEntity entity)
    {
        entity.Id = Guid.NewGuid();
        inMemoryDatabase.Add(entity);
        logger.LogInformation($"Added {entity.GetType().Name}");
        return entity;
    }
    
    public IEnumerable<TEntity> GetAll()
    {
        return inMemoryDatabase.AsEnumerable();
    }

    public TEntity GetById(Guid id)
    {
        return inMemoryDatabase.Where(x => x.Id == id).FirstOrDefault();
    }

    public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
    {
        return inMemoryDatabase.Where(predicate).AsEnumerable();
    }

    public void Update(TEntity entity)
    {
        var existingEntity = inMemoryDatabase.Where(x => x.Id == entity.Id).FirstOrDefault();
        if (existingEntity == null)
            return;
        inMemoryDatabase.Remove(existingEntity);
        inMemoryDatabase.Add(entity);
    }

    public void Delete(Guid id)
    {
        var existingEntity = inMemoryDatabase.Where(x => x.Id == id).FirstOrDefault();
        if (existingEntity == null)
            return;
        inMemoryDatabase.Remove(existingEntity);

    }
}