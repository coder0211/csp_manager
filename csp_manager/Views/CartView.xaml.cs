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
    /// Interaction logic for CartView.xaml
    /// </summary>
    public partial class CartView : UserControl
    {

        HomeView _homeView;

       
        public CartView(HomeView homeView)
        {
            _homeView = homeView;
            InitializeComponent();
            
            lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });
            lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });
            lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });
            lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });
            lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });
            lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });
        }
        private void TempBut_Click(object sender, RoutedEventArgs e)
        {
            _homeView.IsShowDialog = Visibility.Hidden;
        }

        private void txtCustomerName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtCustomerLocation_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtCustomerNote_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnDeleteCart_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void btnContinuteBuy_Click(object sender, RoutedEventArgs e)
        {
            _homeView.IsShowDialog = Visibility.Hidden;
        }
        private void btnComplete_Click(object sender, RoutedEventArgs e)
        {       
           
        }

        private void lstCart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
