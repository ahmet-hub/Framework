using AhmetFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AhmetFramework.Core.DataAccess
{
  public interface IEntityRepository<T> where T : class, IEntity, new()
  {
    public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
    public Task<T> GetAsync(Expression<Func<T, bool>> filter);
    public Task<T> AddAsync(T entity);
    public Task<T> UpdateAsync(T entity);
    public Task DeleteAsync(T entity);

  }
}
