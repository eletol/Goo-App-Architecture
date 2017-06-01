using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.DBContext;

namespace DAL.Collections.Interfaces
{
    public interface IBaseCollection<TEntity, TContext>
        where TEntity : class ,new()
        where TContext : IDbContext

    {
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity GetByID(object id);
        TEntity Insert(TEntity entity);
        List<TEntity> InsertList(List<TEntity> entity);

        void InsertOrEdit(TEntity entity);
        TEntity Delete(object id);
        TEntity Delete(TEntity entityToDelete);
        TEntity Update(TEntity entityToUpdate);
        void DeleteByFilter(Expression<Func<TEntity, bool>> filter);

        TContext ContextObject { get; set; }
    }
}
