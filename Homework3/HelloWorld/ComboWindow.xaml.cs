
using System.Windows;
using System.Data.Entity;
using System.Windows.Controls;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for ComboWindow.xaml
    /// </summary>
    public partial class ComboWindow : Window
    {
        public ComboWindow()
        {
            InitializeComponent();

            var sample = new SampleEntities();
            sample.Users.Load();
            uxComboBox.ItemsSource = sample.Users.Local;
            uxListBox.ItemsSource = sample.Users.Local;
        }

        private void uxComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            uxGrid.DataContext = e.AddedItems[0];
        }

        private void UxListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            uxGrid.DataContext = e.AddedItems[0];
        }
    }
}
