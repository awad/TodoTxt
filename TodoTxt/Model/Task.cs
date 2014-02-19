using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoTxt.Model
{
    public class Task
    {
        public string id { get; set; }
        private int Priority { get; set; }
        private bool IsDone { get; set; }
        public string Description { get; set; }

        public Task()
        {
            id = Guid.NewGuid().ToString();
            IsDone = false;
            Description = "";
            Priority = 5;
        }

        internal object GetCopy()
        {
            Task copy = (Task)this.MemberwiseClone();
            return copy;
        }
    }
}
