using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;


namespace Core.DataAccess.EntityFramework
{
    public class EFEntityRepoBase<TEntity, TContext> : IEntityRepo<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public bool Add(TEntity entity)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception )
            {
                return false;
            }
            
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = EntityState.Deleted;
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public IDataResult<TEntity> Get(Func<TEntity, bool> filter)
        {
            try
            {
                TEntity get;
                using (TContext context = new TContext())
                {
                   get = context.Set<TEntity>().SingleOrDefault(filter);
                }

                return new SuccessDataResult<TEntity>(get);
            }
            catch (Exception)
            {
                return new ErrorDataResult<TEntity>(null);
            }
        }

        public IDataResult<List<TEntity>> GetAll(Func<TEntity, bool> filter = null)
        {
            try
            {
                List<TEntity> getAll;
                using (TContext context = new TContext())
                {
                    getAll = filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
                }

                return new SuccessDataResult<List<TEntity>>(getAll);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<TEntity>>(null);
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    var updatedEntity = context.Entry(entity);
                    updatedEntity.State = EntityState.Modified;
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
