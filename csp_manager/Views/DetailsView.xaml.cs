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
using Excel = Microsoft.Office.Interop.Excel;

namespace csp_manager.Views
{
    /// <summary>
    /// Interaction logic for DetailsView.xaml
    /// </summary>
    public partial class DetailsView : Window
    {
        QueryData QD = new QueryData();
        Func f = new Func();
        invoices inv;

        public DetailsView(int invoice_id)
        {
            InitializeComponent();

            inv = QD.GetInvoice(invoice_id, out string err);
            txtCustomerName.Text = inv.customer_name;
            txtPhoneNumber.Text = inv.customer_phone_number;
            txtCustomerLocation.Text = inv.customer_address;
            List<invoice_details> invd = QD.GetInvoiceDetails(invoice_id);
            //long tongtien = 0;
            foreach (var el in invd)
            {
                //MessageBox.Show(el.plants.ToString());
                el.plants = QD.GetPlant(el.plant_id, out err);
                lstDetails.Items.Add(new Plant_ { Plant = el.plants, Price = el.plant_price, Quantity = el.plant_amount });
                //tongtien += (long)el.plants.plant_price * el.plant_amount;
            }
            txtTongTien.Text = f.NumberToStr(inv.invoice_total);
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
            var ExcelApp = new Excel.Application
            {
                Visible = true
            };
            var wb = ExcelApp.Workbooks.Add(1);
            var ws = wb.Worksheets[1];

            int row = 1;
            int col = 1;
            ws.Cells[row, col].Font.Bold = true;
            ws.Cells[row, col++] = "Hoá đơn ngày";
            ws.Cells[row++, col--] = inv.invoice_created_at.ToShortDateString();
            ws.Cells[row, col].Font.Bold = true;
            ws.Cells[row, col++] = "Tên khách";
            ws.Cells[row++, col--] = inv.customer_name;
            ws.Cells[row, col].Font.Bold = true;
            ws.Cells[row, col++] = "Số điện thoại";
            ws.Cells[row++, col--] = inv.customer_phone_number;
            ws.Cells[row, col].Font.Bold = true;
            ws.Cells[row, col++] = "Địa chỉ";
            ws.Cells[row++, col--] = inv.customer_address;
            ws.Cells[row, col].Font.Bold = true;
            ws.Cells[row, col++] = "Ghi chú";
            ws.Cells[row++, col--] = inv.invoice_note;
            row++;
            ws.Cells[row, col].Font.Bold = true;
            ws.Cells[row++, col] = "Chi tiết sản phẩm";
            ws.Cells[row, col].Font.Bold = true;
            ws.Cells[row, col++] = "STT";
            ws.Cells[row, col].Font.Bold = true;
            ws.Cells[row, col++] = "Tên sản phẩm";
            ws.Cells[row, col].Font.Bold = true;
            ws.Cells[row, col++] = "Số lượng";
            ws.Cells[row, col].Font.Bold = true;
            ws.Cells[row++, col++] = "Thành tiền";
            int i = 1;
            long tongtien = 0;
            foreach (Plant_ lvi in lstDetails.Items)
            {
                col = 1;
                ws.Cells[row, col++] = i++;
                ws.Cells[row, col++] = lvi.Plant.plant_name;
                ws.Cells[row, col++] = lvi.Quantity;
                ws.Cells[row++, col++] = lvi.Price;
                tongtien += (long)lvi.Plant.plant_price * lvi.Quantity;
            }
            ws.Cells[row, 1].Font.Bold = true;
            ws.Cells[row, 1] = "Tổng tiền";
            ws.Cells[row, 4] = tongtien;

            ws.Range[ws.Cells[row, 1], ws.Cells[row, 3]].Merge();
            ws.Columns.AutoFit();
        }
    }
}