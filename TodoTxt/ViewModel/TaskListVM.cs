using System.Collections.Generic;
using TodoTxt.Model;

namespace TodoTxt.ViewModel
{
    public static class TaskListVM
    {
        public static List<Task> TaskList = new List<Task>();

        public static void AddTask(Task task)
        {
            TaskList.Add(task);
        }

    }
}