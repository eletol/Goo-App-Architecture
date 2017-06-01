using System;
using DAL.Repository.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        void Dispose(bool disposing);

        TRepository Repository<TEntity, TRepository>() where TEntity : class
            where TRepository : IBaseRepository<TEntity>;
    }
}