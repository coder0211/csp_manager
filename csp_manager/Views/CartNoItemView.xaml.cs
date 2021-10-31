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
using System.Windows.Shapes;

namespace csp_manager.Views
{
    /// <summary>
    /// Interaction logic for CartNoItemView.xaml
    /// </summary>
    public partial class CartNoItemView : Window
    {
        //HomeView _homeView;
        public CartNoItemView(HomeView homeView)
        {
            InitializeComponent();
        }

        private void txtCustomer_Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPhone_Number_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtCustomer_Location_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtCustomer_Note_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
