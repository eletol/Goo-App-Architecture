using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BL.BussinessMangers.Interfaces;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;

namespace BL.Domain.BussinessMangers.Classes
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TRepository"></typeparam>
    public class BaseBussinessManger<TEntity, TRepository> : IBaseBussinessManger<TEntity> where TEntity : class
        where TRepository : IBaseRepository<TEntity>
    {
        public BaseBussinessManger(IUnitOfWork _uow)
        {
            if (_uow == null)
            {
                throw new ArgumentNullException("no repository provided");
            }
            UnitOfWork = _uow;
            Repository = UnitOfWork.Repository<TEntity, TRepository>();
        }

        protected IBaseRepository<TEntity> Repository { get; set; }
        protected IUnitOfWork UnitOfWork { get; set; }


        public virtual TEntity GetById(object id)
        {
            return Repository.GetById(id);
        }
        public virtual void DeleteByFilter(Expression<Func<TEntity, bool>> filter)
        {
             Repository.DeleteByFilter(filter);
            UnitOfWork.Save();

        }

        public virtual TEntity Save(TEntity item)
        {
            var addedItem = Repository.Save(item);

            UnitOfWork.Save();
            return addedItem;
        }
   public virtual List<TEntity> SaveList(List<TEntity> items)
        {
            var addedItem = Repository.SaveList(items);

            UnitOfWork.Save();
            return addedItem;
        }
        public virtual TEntity Update(TEntity entityToUpdate)
        {
            var editedItem = Repository.Update(entityToUpdate);
            UnitOfWork.Save();
            return editedItem;
        }

        public virtual TEntity Delete(object id)
        {
            var deletedItem = Repository.Delete(id);
            UnitOfWork.Save();
            return deletedItem;
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Repository.Get(filter, orderBy, includeProperties);
        }
    }
}