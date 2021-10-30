using csp_manager.DataContext;
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
using System.Windows.Shapes;

namespace csp_manager.Views
{
    /// <summary>
    /// Interaction logic for DetailsView.xaml
    /// </summary>
    public partial class DetailsView : Window
    {
        QueryData QD = new QueryData();
        Func f = new Func();

        public DetailsView(int invoice_id)
        {
            InitializeComponent();

            invoices inv = QD.GetInvoice(invoice_id, out string err);
            txtCustomerName.Text = inv.customer_name;
            txtPhoneNumber.Text = inv.customer_phone_number;
            txtCustomerLocation.Text = inv.customer_address;
            List<invoice_details> invd = QD.GetInvoiceDetails(invoice_id);
            int tongtien = 0;
            foreach (var el in invd)
            {
                //MessageBox.Show(el.plants.ToString());
                el.plants = QD.GetPlant(el.plant_id, out err);
                lstDetails.Items.Add(new Plant_ { Plant = el.plants, Quantity = el.plant_amount });
                tongtien += (int)el.plants.plant_price * el.plant_amount;
            }
            txtTongTien.Text = f.NumberToStr(tongtien);
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

        private void lstDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCloseDetails_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPrintDetails_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
