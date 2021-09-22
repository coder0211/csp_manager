using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddItemView.xaml
    /// </summary>
    public partial class AddItemView : UserControl
    {
        HomeView _homeView;
        public AddItemView(HomeView homeView)
        {
            _homeView = homeView;
            InitializeComponent();
        }
        private void txtSupplier_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNote_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtLocation_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtUnit_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtType_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _homeView.IsShowDialog = Visibility.Hidden;
        }

        private void btnCompleted_Click(object sender, RoutedEventArgs e)
        {
            _homeView.IsShowDialog = Visibility.Hidden;
        }
    }
}
