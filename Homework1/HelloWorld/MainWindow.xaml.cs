
using System.Windows;

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
            //WindowState = WindowState.Maximized;
        }

        public override void EndInit()
        {
            base.EndInit();
            uxContainer.DataContext = user;
        }

        private void UxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password:" + uxPassword.Text);
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
