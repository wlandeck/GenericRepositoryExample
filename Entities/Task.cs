using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MyTask
    {
        public Guid IdKey { get; set; }
        public string Task { get; set; }
        public string Description { get; set; }
        public ICollection<TaskList> TaskLists { get; set; }

    }
}
