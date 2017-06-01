using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.Collections.Interfaces;
using DAL.DBContext;
using DAL.Repository.Interfaces;

namespace DAL.Repository.Classes
{
    public class BaseRepository<TCollection, TItem> : IBaseRepository<TItem>
        where TCollection : IBaseCollection<TItem,IDbContext>, new() where TItem : class, new()
        
    {
        public BaseRepository(IDbContext context)
        {
            Collection = new TCollection() { ContextObject = context };
        }

        public TCollection Collection { get; set; }

        public virtual TItem GetById(object id)
        {
            return Collection.GetByID(id);
        }

        public virtual TItem Save(TItem item)
        {
            return Collection.Insert(item);
        }
        public virtual List<TItem> SaveList(List<TItem> items)
        {
            return Collection.InsertList(items);
        }
        public virtual void SaveOrEdit(TItem item)
        {
             Collection.InsertOrEdit(item);
        }
        public virtual TItem Update(TItem entityToUpdate)
        {
            return Collection.Update(entityToUpdate);
        }

        public virtual TItem Delete(object id)
        {
            return Collection.Delete(id);
        }
        public virtual void DeleteByFilter(Expression<Func<TItem, bool>> filter)
        {
             Collection.DeleteByFilter(filter);
            
        }
         
        public virtual IQueryable<TItem> Get(Expression<Func<TItem, bool>> filter = null,
            Func<IQueryable<TItem>, IOrderedQueryable<TItem>> orderBy = null,
            params Expression<Func<TItem, object>>[] includeProperties)
        {
            return Collection.Get(filter, orderBy, includeProperties);
        }
    }
}