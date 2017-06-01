using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using DAL.Collections.Interfaces;
using DAL.DBContext;


namespace DAL.Collections.Classes
{
    public class BaseCollection<TModel, TContext> :
        IBaseCollection<TModel, TContext> where TModel : class, new()
        where TContext : IDbContext
    {
        private TContext _context;
        private DbSet<TModel> dbSet;
        public TContext ContextObject
        {
            get { return _context; }
            set
            {
                _context = value;
                dbSet = ContextObject.Set<TModel>();
            }
        }
        public virtual IQueryable<TModel> Get(
            Expression<Func<TModel, bool>> filter = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            return query;
        }

        public virtual TModel GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public TModel Insert(TModel entity)
        {
            return dbSet.Add(entity);
        }
        public List<TModel> InsertList(List<TModel> entities)
        {
            return dbSet.AddRange(entities).ToList();
        }
        public void InsertOrEdit(TModel entity)
        {
            dbSet.AddOrUpdate(entity);
        }
        public virtual TModel Delete(object id)
        {
            var entityToDelete = dbSet.Find(id);
            return Delete(entityToDelete);
        }
        public virtual void DeleteByFilter(Expression<Func<TModel, bool>> filter)
        {
          IQueryable<TModel> query = dbSet;

              if (filter != null)
            {
                query = query.Where(filter);
            }
            dbSet.RemoveRange(query);
            
        }
        public virtual TModel Delete(TModel entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            return dbSet.Remove(entityToDelete);
        }

        public virtual TModel Update(TModel entityToUpdate)
        {
            var entity = dbSet.Attach(entityToUpdate);
         _context.Entry(entityToUpdate).State = EntityState.Modified;
            return entity;
        }
    }
}
