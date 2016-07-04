using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.domain.Abstract;

namespace TODO.domain.UOF
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Entities.Task> Tasks { get; }

        void SaveChanges();
    }
}
