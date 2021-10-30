using csp_manager.DataQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Interaction logic for ItemRegisterView.xaml
    /// </summary>
    public partial class ItemRegisterView : UserControl
    {
        QueryData QD = new QueryData();

        public ItemRegisterView()
        {
            InitializeComponent();
        }

        public bool IsEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnRegister(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Length > 0 && txtEmail.Text.Length > 0 && txtPassword.Text.Length > 0 && txtComfirmPassword.Text.Length > 0)
            {
                if (IsEmail(txtEmail.Text))
                {
                    if (txtPassword.Text.Equals(txtComfirmPassword.Text))
                    {
                        int r = QD.Reg(txtName.Text, txtEmail.Text, txtPassword.Text, out string err);
                        if (!string.IsNullOrEmpty(err)) MessageBox.Show(err);
                        else
                        {
                            Window mainWindow = Application.Current.MainWindow;
                            mainWindow.Content = new HomeView(r);
                        }
                    }
                    else MessageBox.Show("Mật khẩu nhập lại không trùng khớp!");
                }
                else MessageBox.Show("Email không hợp lệ!");
            }
            else MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtComfirmPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
