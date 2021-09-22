using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace csp_manager.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
       


        public LoginView()
        {
            InitializeComponent();
            LoginFrame.Content = new ItemLoginView();
            ColorLogin.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginFrame.NavigationService.Navigate(new ItemLoginView());
            ColorLogin.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            ColorRegister.Background = new SolidColorBrush(Color.FromRgb(95,175,87));
        }

        private void btnResigter_Click(object sender, RoutedEventArgs e)
        {
            LoginFrame.NavigationService.Navigate(new ItemRegisterView());
            ColorLogin.Background = new SolidColorBrush(Color.FromRgb(95,175,87));
            ColorRegister.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void btnInfor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
