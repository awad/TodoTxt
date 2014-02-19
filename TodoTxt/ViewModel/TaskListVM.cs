using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using TodoTxt.Model;

namespace TodoTxt.ViewModel
{
    public static class TaskListVM
    {
        public static ObservableCollection<Task> TaskList {get; set;}

        public static List<Task> SelectedTaskList = new List<Task>();

        public static void AddTask(Task task)
        {
            TaskList.Add(task);
            SaveTasks();
        }


        public static void RemoveSelectedTasks()
        {
            foreach (Task task in SelectedTaskList)
            {
                if (TaskList.Contains(task))
                {
                    TaskList.Remove(task);
                }
            }
            SaveTasks();
        }
        public static void GetSavedTasks()
        {
            ObservableCollection<Task> a = new ObservableCollection<Task>();

            foreach (Object o in IsolatedStorageSettings.ApplicationSettings.Values)
            {
                a.Add((Task)o);
            }

            TaskList = a;

        }

        public static void SaveTasks()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            foreach (Task a in TaskList)
            {
                if (settings.Contains(a.id))
                {
                    settings[a.id] = a;
                }
                else
                {
                    settings.Add(a.id, a.GetCopy());
                }
            }

            settings.Save();
            //MessageBox.Show("Finished saving tasks");
        }


    }
}