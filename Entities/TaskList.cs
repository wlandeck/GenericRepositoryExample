﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TaskList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<MyTask> Tasks { get; set; }
    }
}
