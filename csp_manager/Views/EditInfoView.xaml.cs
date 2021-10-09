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
    /// Interaction logic for EditInfoView.xaml
    /// </summary>
    public partial class EditInfoView : Window
    {
        public EditInfoView()
        {
            InitializeComponent();
        }

        private void txtNamePlant_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtEditQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtEditUnit_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtEditPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtEditSupplier_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtEditLocation_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtEditNote_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnEditDelete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEditComplete(object sender, RoutedEventArgs e)
        {
            
            this.Close();
            Window editComplete = new EditSuccessView();
            editComplete.ShowDialog();
        }
    }
}
