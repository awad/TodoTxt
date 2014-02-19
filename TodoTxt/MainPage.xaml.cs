using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TodoTxt.Resources;
using TodoTxt.ViewModel;
using System.Windows.Media;
using TodoTxt.Model;
using System.Windows.Navigation;

namespace TodoTxt
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            LoadTaskList();
        }

        private void LoadTaskList()
        {
            TaskListVM.GetSavedTasks();
            lstTasks.ItemsSource = TaskListVM.TaskList;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            LoadTaskList();
        }

        /// <summary>
        /// Recursively get the item.
        /// </summary>
        /// <typeparam name="T">The item to get.</typeparam>
        /// <param name="parents">Parent container.</param>
        /// <param name="objectList">Item list</param>
        public static void GetItemsRecursive<T>(DependencyObject parents, ref List<T> objectList) where T : DependencyObject
        {
            var childrenCount = VisualTreeHelper.GetChildrenCount(parents);

            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parents, i);

                if (child is T)
                {
                    objectList.Add(child as T);
                }

                GetItemsRecursive<T>(child, ref objectList);
            }

            return;
        }

        private void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get item of LongListSelector.
            List<UserControl> listItems = new List<UserControl>();
            GetItemsRecursive<UserControl>(lstTasks, ref listItems);

            // Selected.
            if (e.AddedItems.Count > 0 && e.AddedItems[0] != null)
            {
                foreach (UserControl userControl in listItems)
                {
                    if (e.AddedItems[0].Equals(userControl.DataContext))
                    {
                        TaskListVM.SelectedTaskList.Add(e.AddedItems[0] as Task);
                        VisualStateManager.GoToState(userControl, "Selected", true);
                    }
                }
            }
            // Unselected.
            if (e.RemovedItems.Count > 0 && e.RemovedItems[0] != null)
            {
                foreach (UserControl userControl in listItems)
                {
                    if (e.RemovedItems[0].Equals(userControl.DataContext))
                    {
                        TaskListVM.SelectedTaskList.Remove(e.RemovedItems[0] as Task);
                        VisualStateManager.GoToState(userControl, "Normal", true);
                    }
                }
            }


            //Appbar
            var btnEdit = new ApplicationBarIconButton(new Uri("/assets/images/edit.png", UriKind.Relative)) { Text = "Edit" };
            if (this.ApplicationBar.Buttons.Count < 2)
            {
                

                btnEdit.Click += new EventHandler(btnEdit_Click);
                this.ApplicationBar.Buttons.Add(btnEdit);
            }
            var btnDelete = new ApplicationBarIconButton(new Uri("/assets/images/delete.png", UriKind.Relative)) { Text = "Delete" };

            if (this.ApplicationBar.Buttons.Count < 3)
            {

                btnDelete.Click += new EventHandler(btnDelete_Click);
                this.ApplicationBar.Buttons.Add(btnDelete);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {            
                TaskListVM.RemoveSelectedTasks();          
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnNewTrip_Click(object sender, EventArgs e)
        {
            NavigationManager.NavigateToPage(this.NavigationService, "/TodoTxt;component/NewTask.xaml", UriKind.Relative);
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}