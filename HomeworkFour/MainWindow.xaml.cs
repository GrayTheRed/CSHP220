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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeworkFour
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.ZipCode zip = new Models.ZipCode();
        public MainWindow()
        {
            InitializeComponent();
            uxContainer.DataContext = zip;
            uxSubmit.IsEnabled = false;
        }

        private void zipTextChange(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (IsZipError())
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.IsEnabled = false;
            }

        }

        private bool IsZipError()
        {
            return ((zip.ZipError == null || zip.ZipError == ""));
        }
    }
}
