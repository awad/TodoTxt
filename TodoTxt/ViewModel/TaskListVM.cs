using System.Collections.Generic;
using TodoTxt.Model;

namespace TodoTxt.ViewModel
{
    public class TaskListVM
    {
        List<Task> taskList = new List<Task>();

        public void AddTask(Task task)
        {
            taskList.Add(task);
        }

    }
}