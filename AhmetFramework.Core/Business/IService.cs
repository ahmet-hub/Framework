using AhmetFramework.Core.Entities;
using AhmetFramework.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AhmetFramework.Core.Business
{
  public interface IService<T> where T : class, IEntity, new()
  {
    public Task<IDataResult<IEnumerable<T>>> GetAllAsync(Expression<Func<T, bool>> filter = null);
    public Task<IDataResult<T>> GetAsync(Expression<Func<T, bool>> filter);
    public Task<IDataResult<T>> AddAsync(T entity);
    public Task<IDataResult<T>> UpdateAsync(T entity);
    public Task<IResult> DeleteAsync(T entity);
  }
}
