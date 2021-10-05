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

namespace csp_manager.Views
{
    /// <summary>
    /// Interaction logic for SettingView.xaml
    /// </summary>
    public partial class SettingView : UserControl
    {
        public SettingView()
        {
            InitializeComponent();
        }

        private void btnAcount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSecurity_Click(object sender, RoutedEventArgs e)
        {
            homeFrame.NavigationService.Navigate(new SecuritySettingView());
        }

        private void btnAppInfo_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnFeedBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
