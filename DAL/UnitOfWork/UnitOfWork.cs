using System;
using System.Collections;
using DAL.DBContext;
using DAL.Repository.Interfaces;

namespace DAL.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork
        where TContext : IDbContext, new()
    {
        private readonly IDbContext _context;

        private bool _disposed;
        private Hashtable _repositories;

        public UnitOfWork()
        {
            _context = new TContext();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
           _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();

            _disposed = true;
        }

        public TRepository Repository<TEntity, TRepository>() where TEntity : class
            where TRepository : IBaseRepository<TEntity>
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof (TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                object repositoryInstance;
                var repositoryType = typeof (TRepository);
                if (repositoryType.IsGenericType)
                {
                    repositoryInstance = Activator.CreateInstance(repositoryType
                        .MakeGenericType(typeof (TEntity)), _context);
                }
                else
                {
                    repositoryInstance = Activator.CreateInstance(repositoryType, _context);
                }
                _repositories.Add(type, repositoryInstance);
            }

            return (TRepository) _repositories[type];
        }
    }
}