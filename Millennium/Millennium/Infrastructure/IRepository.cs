using System.Collections;
using Millennium.Models;

namespace Millennium.Infrastructure;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    public TEntity Add(TEntity entity);
    public void Delete(Guid id);
    public IEnumerable<TEntity> GetAll();
    public TEntity GetById(Guid id);
    public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
    public void Update(TEntity entity);
}