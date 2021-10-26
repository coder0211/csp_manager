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
    /// Interaction logic for LogoutWarning.xaml
    /// </summary>
    public partial class LogoutWarning : Window
    {
        
        public LogoutWarning()
        {
            
            InitializeComponent();
           
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

            this.Hide();
            Window mainWindow = Application.Current.MainWindow;
            mainWindow.Close();
            Window loginWindow = new MainWindow();
            loginWindow.ShowDialog();
            this.Close();
        }
        private void btnNoLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
