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
    /// Interaction logic for ItemLoginView.xaml
    /// </summary>




    public partial class ItemLoginView : UserControl
    {
        QueryData QD = new QueryData();

        private bool isMemorize;

        public bool IsMemorize { get => isMemorize; set => isMemorize = value; }

        public ItemLoginView()
        {
            InitializeComponent();
        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text.Length > 0 && txtPassword.Password.Length > 0)
            {
                int r = QD.Login(txtEmail.Text, txtPassword.Password);
                if (r == -1) MessageBox.Show("Tìm khoản không tìm thấy!");
                else if (r == 0) MessageBox.Show("Mật khẩu không chính xác!");
                else
                {
                    //Window mainWindow = Application.Current.MainWindow;
                    //mainWindow.Content = new VerifyEmailView();
                    Window mainWindow = Application.Current.MainWindow;
                    mainWindow.Content = new HomeView(r);
                }
            }
            else MessageBox.Show("Vui lòng nhập email và mật khẩu!");
        }

        private void btnMemorize_Click(object sender, RoutedEventArgs e)
        {
            IsMemorize = !IsMemorize;
            if (isMemorize == true)
            {
                btnMemorize.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }

            else
            {
                btnMemorize.Background = new SolidColorBrush(Color.FromRgb(95, 175, 87));
            }

        }
    }
}
