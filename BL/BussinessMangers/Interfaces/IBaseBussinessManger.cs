using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BL.BussinessMangers.Interfaces
{
    public interface IBaseBussinessManger<TEntity> where TEntity : class
    {
        TEntity GetById(object id);
        TEntity Save(TEntity item);
        TEntity Update(TEntity entityToUpdate);
        TEntity Delete(object id);

        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties);

        List<TEntity> SaveList(List<TEntity> items);
        void DeleteByFilter(Expression<Func<TEntity, bool>> filter);



    }
}