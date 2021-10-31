using csp_manager.DataQuery;
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
        private int user_id;

        public ChangePasswordView(int user_id = 0)
        {
            this.user_id = user_id;
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
            if (txtOldPass.Text.Length > 0 && txtNewPassword.Text.Length > 0 && txtConfirmNewPassword.Text.Length > 0)
            {
                if (string.Equals(txtNewPassword.Text, txtConfirmNewPassword.Text))
                {
                    if (string.Equals(txtOldPass.Text, txtNewPassword.Text))
                    {
                        Window changePassWarning1View = new ChangePassWarning1View();
                        changePassWarning1View.ShowDialog();
                    }
                    else
                    {
                        QueryData QD = new QueryData();
                        bool r = QD.ChangePass(user_id, txtOldPass.Text, txtNewPassword.Text, out string err);
                        if (r)
                        {
                            Window OKPass = new ChangePassSuccessView();
                            OKPass.ShowDialog();
                            txtNewPassword.Text = "";
                            txtConfirmNewPassword.Text = "";
                            txtOldPass.Text = "";
                        }
                        else MessageBox.Show(err);
                    }
                }
                else
                {
                    Window changePassWarning2View = new ChangePassWarning2View();
                    changePassWarning2View.ShowDialog();
                }
            }
            else
            {
                Window fillInfoWarningView = new FillInfoWarningView();
                fillInfoWarningView.ShowDialog();
            }
        }
    }
}
