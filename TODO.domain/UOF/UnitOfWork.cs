using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.domain.Abstract;
using TODO.domain.Concrete;

namespace TODO.domain.UOF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFDbContext _context = new EFDbContext();
        public GenericRepository<Entities.Task> Tasks
        {
            get
            {
                if (_task == null)
                {
                    _task = new GenericRepository<Entities.Task>(_context);
                }
                return _task;
            }
        }
        private bool _disposed;
        private GenericRepository<Entities.Task> _task;
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
