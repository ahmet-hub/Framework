using AhmetFramework.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace AhmetFramework.Core.DataAccess.EntityFramework {
  public class EfEntityRepositoryBase < TEntity, TContext >: IEntityRepository < TEntity >
    where TEntity: class, IEntity, new()
  where TContext: DbContext, new() {


    public async Task < TEntity > AddAsync(TEntity entity) {

      using(var context = new TContext()) {


        await context.Set < TEntity > ().AddAsync(entity);

        await context.SaveChangesAsync();

        return entity;

      }
    }

    public async Task DeleteAsync(TEntity entity) {
      using(var context = new TContext()) {
        context.Set < TEntity > ().Remove(entity);
        await context.SaveChangesAsync();

      }
    }
    public async Task < IEnumerable < TEntity >> GetAllAsync(Expression < Func < TEntity, bool >> filter = null) {

      using(var context = new TContext()) {
        var entities = filter == null ?
          context.Set < TEntity > ().ToListAsync() :
          context.Set < TEntity > ().Where(filter).ToListAsync();

        return await entities;

      }

    }

    public async Task < TEntity > GetAsync(Expression < Func < TEntity, bool >> filter) {
      using(var context = new TContext()) {
        var data = await context.Set < TEntity > ().SingleOrDefaultAsync(filter);
        return data;
      }
    }

    public async Task < TEntity > UpdateAsync(TEntity entity) {
      using(var context = new TContext()) {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return entity;
      }
    }

  }
}
