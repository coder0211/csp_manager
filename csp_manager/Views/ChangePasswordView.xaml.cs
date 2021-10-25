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
    /// Interaction logic for ChangePasswordView.xaml
    /// </summary>
    public partial class ChangePasswordView : UserControl
    {
        public ChangePasswordView()
        {
            InitializeComponent();
        }

        private void txtOldPass_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNewPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtConfirmNewPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnOkPass_Click(object sender, RoutedEventArgs e)
        {
            Window OKPass = new ChangePassSuccessView();
            OKPass.ShowDialog();
        }
    }
}
