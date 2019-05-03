using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        CollectionView View { get; set; }

        List<Models.User> users = new List<Models.User>();

        public SecondWindow()
        {
            InitializeComponent();

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;
            View = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            
        }
        private void uxListColumnHeaderName_Click(object sender, RoutedEventArgs e)
        {
            if (View.SortDescriptions.Count >= 1)
            {
                View.SortDescriptions.RemoveAt(0);
            }
            View.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void uxListColumnHeaderPwd_Click(object sender, RoutedEventArgs e)
        {
            if (View.SortDescriptions.Count >= 1)
            {
                View.SortDescriptions.RemoveAt(0);
            }
            View.SortDescriptions.Add(new System.ComponentModel.SortDescription("Password", System.ComponentModel.ListSortDirection.Ascending));
        }
    }
}
