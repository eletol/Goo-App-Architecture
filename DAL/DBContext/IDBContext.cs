using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DAL.DBContext
{
    public interface IDbContext
    {
        int SaveChanges();
        DbEntityEntry Entry(object o);
        void Dispose();
         DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}