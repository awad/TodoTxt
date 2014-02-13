using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoTxt.Model
{
    public class Task
    {
        private int Priority { get; set; }
        private bool IsDone { get; set; }
        public string Description { get; set; }

        public Task()
        {
            IsDone = false;
            Description = "";
            Priority = 5;
        }
    }
}
