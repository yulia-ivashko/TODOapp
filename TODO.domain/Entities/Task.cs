using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.domain.Entities
{
    public class Task
    {
        //[Key]
        public int TaskId { get; set; }
        public string Name { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
