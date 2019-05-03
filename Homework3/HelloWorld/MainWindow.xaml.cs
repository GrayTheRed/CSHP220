
using System.Windows;
using System.Data.Entity;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.User user = new Models.User();

        public MainWindow()
        {
            InitializeComponent();
            uxSubmit.IsEnabled = false;
            uxContainer.DataContext = user;
            var sample = new SampleEntities();
            sample.Users.Load();
            uxList.ItemsSource = sample.Users.Local;
        }

        //public override void EndInit()
        //{
        //    base.EndInit();
        //}

        private void UxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password:" + uxPassword.Text);

            var window = new SecondWindow();
            Application.Current.MainWindow = window;
            Close();
            window.Show();
        }

        private void nameTextChange(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if(IsNameOrPasswordError())
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.IsEnabled = false;
            }
        }

        private void passwordTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (IsNameOrPasswordError())
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.IsEnabled = false;
            }

        }

        private bool IsNameOrPasswordError()
        {
            return ((user.NameError == null || user.NameError == "") && (user.PasswordError == null || user.PasswordError == ""));
        }
    }
}
