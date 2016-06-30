using System.Collections.Generic;
using System.Linq;
using TODO.domain.Abstract;

namespace TODO.domain.Concrete
{
    public class EFTaskRepository:ITasksRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Entities.Task> Tasks
        {
            get
            {
                return context.Tasks.ToList();
            }
        }
    }
}
