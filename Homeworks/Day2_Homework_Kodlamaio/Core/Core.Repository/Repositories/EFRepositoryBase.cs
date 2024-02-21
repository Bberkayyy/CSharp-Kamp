using Core.Repository.EntityBaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository.Repositories;

public class EFRepositoryBase<TContext, TEntity, TId> : IRepository<TEntity, TId>
    where TContext : DbContext
    where TEntity : Entity<TId>
{
    public TContext Context { get; set; }

    public EFRepositoryBase(TContext context)
    {
        Context = context;
    }

    public void Add(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
        Context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        if (predicate is not null)
            queryable = queryable.Where(predicate);
        if (include is not null)
            queryable = include(queryable);
        return queryable.ToList();
    }

    public TEntity GetByFilter(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        queryable = queryable.Where(predicate);
        if (include is not null)
            queryable = include(queryable);
        return queryable.FirstOrDefault();
    }

    public IQueryable<TEntity> Query() => Context.Set<TEntity>();


    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
        Context.SaveChanges();
    }
}
