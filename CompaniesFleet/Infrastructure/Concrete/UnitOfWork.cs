using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Contract;

namespace Infrastructure.Concrete
{

    public class UnitOfWork :IUnitOfWork , IDisposable
    {
        private readonly Context _dbContext;
        public Context Context { get { return _dbContext; } }


        public UnitOfWork(Context context)
        {
            _dbContext = context;
        }

        public UnitOfWork()
        {
            _dbContext = new Context();
        }

        public DbContextTransaction BeginTransaction()
        {
            return _dbContext.AppDbContext.Database.BeginTransaction();
        }


        public void SaveChanges()
        {
            _dbContext.AppDbContext.SaveChanges();
        }

        

        #region Implementation of IDispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_disposed) return;
            _dbContext.Dispose();
            _disposed = true;
        }

        private bool _disposed;

        ~UnitOfWork()
        {
            Dispose(false);
        }

        #endregion
    }
}
