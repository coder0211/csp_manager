using csp_manager.DataContext;
using csp_manager.DataQuery;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for HistoryView.xaml
    /// </summary>
    public class Invoice
    {
        public int STT { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Total { get; set; }
    }

    public partial class HistoryView : UserControl
    {
        public HistoryView()
        {
            InitializeComponent();
            //lstHistory.Items.Add(new {STT = "1", Name = "Trần Văn Bửu Tú", Date = "16/09/2021", Totals = "4.300.000 vnđ" });
            //lstHistory.Items.Add(new { STT = "2", Name = "Nguyễn Đức Hòa", Date = "16/09/2021", Totals = "1.330.000 vnđ" });
            //lstHistory.Items.Add(new { STT = "3", Name = "Nguyễn Thiên Minh", Date = "16/09/2021", Totals = "4.300.000 vnđ" });
            //lstHistory.Items.Add(new { STT = "4", Name = "Nguyễn Văn Thành Phát", Date = "16/09/2021", Totals = "5.300.000 vnđ" });
            //lstHistory.Items.Add(new { STT = "5", Name = "Trần Văn Bửu Tú", Date = "16/09/2021", Totals = "1.300.000 vnđ" });
            //lstHistory.Items.Add(new { STT = "6", Name = "Nguyễn Đức Hòa", Date = "16/09/2021", Totals = "140.000 vnđ" });
            //lstHistory.Items.Add(new { STT = "7", Name = "Nguyễn Văn Thành Phát", Date = "16/09/2021", Totals = "4.300.000 vnđ" });
            //lstHistory.Items.Add(new { STT = "8", Name = "Nguyễn Đức Hòa", Date = "16/09/2021", Totals = "1.330.000 vnđ" });

            LoadInvoices();
        }

        private void LoadInvoices(int y = 0, int m = 0)
        {
            lstHistory.Items.Clear();
            QueryData QD = new QueryData();
            Func f = new Func();
            List<invoices> inv = (y == 0 && m == 0) ? QD.GetInvoices() : QD.GetInvoices(y, m);
            foreach (var v in inv)
            {
                lstHistory.Items.Add(new Invoice { STT = v.invoice_id, Name = v.customer_name, Date = v.invoice_created_at.ToShortDateString(), Total = f.NumberToStr(v.invoice_total) + " VNĐ" });
            }
        }

        private void lstHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListView)sender;
            var el = (Invoice)item.SelectedItem;
            if (el != null)
            {
                //MessageBox.Show(el.STT.ToString());
                Window detailsView = new DetailsView(el.STT);
                detailsView.ShowDialog();
                item.SelectedIndex = -1;
            }
        }

        private void dtpNgay_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(dtpNgay.SelectedDate.Value.Year.ToString());
            LoadInvoices(dtpNgay.SelectedDate.Value.Year, dtpNgay.SelectedDate.Value.Month);
        }
    }
}
