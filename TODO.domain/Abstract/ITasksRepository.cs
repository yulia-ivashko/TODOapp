using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.domain.Abstract
{
    public interface ITasksRepository
    {
        IEnumerable<Entities.Task> Tasks { get; }
    }
}
