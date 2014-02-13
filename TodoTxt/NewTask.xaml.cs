using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TodoTxt.Model;

namespace TodoTxt
{
    public partial class NewTask : PhoneApplicationPage
    {
        public NewTask()
        {
            InitializeComponent();
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            Task newTask = new Task {Description = tbTask.Text};
            NavigationManager.NavigateToPage(this.NavigationService, "/TodoTxt;component/MainPage.xaml", UriKind.Relative);
        }
    }
}