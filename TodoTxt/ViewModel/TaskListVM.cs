using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TodoTxt.Model;

namespace TodoTxt.ViewModel
{
    public static class TaskListVM
    {
        public static ObservableCollection<Task> TaskList = new ObservableCollection<Task>();

        public static List<Task> SelectedTaskList = new List<Task>();

        public static void AddTask(Task task)
        {
            TaskList.Add(task);
        }


        internal static void RemoveSelectedTasks()
        {
            foreach (Task task in SelectedTaskList)
            {
                if (TaskList.Contains(task))
                {
                    TaskList.Remove(task);
                }
            }
        }

    }
}