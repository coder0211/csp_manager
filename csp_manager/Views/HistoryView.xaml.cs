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
    /// Interaction logic for HistoryView.xaml
    /// </summary>
    public partial class HistoryView : UserControl
    {
        public HistoryView()
        {
            InitializeComponent();
            lstHistory.Items.Add(new {STT = "1", Name = "Trần Văn Bửu Tú", Date = "16/09/2021", Totals = "4.300.000 vnđ" });
            lstHistory.Items.Add(new { STT = "2", Name = "Nguyễn Đức Hòa", Date = "16/09/2021", Totals = "1.330.000 vnđ" });
            lstHistory.Items.Add(new { STT = "3", Name = "Nguyễn Thiên Minh", Date = "16/09/2021", Totals = "4.300.000 vnđ" });
            lstHistory.Items.Add(new { STT = "4", Name = "Nguyễn Văn Thành Phát", Date = "16/09/2021", Totals = "5.300.000 vnđ" });
            lstHistory.Items.Add(new { STT = "5", Name = "Trần Văn Bửu Tú", Date = "16/09/2021", Totals = "1.300.000 vnđ" });
            lstHistory.Items.Add(new { STT = "6", Name = "Nguyễn Đức Hòa", Date = "16/09/2021", Totals = "140.000 vnđ" });
            lstHistory.Items.Add(new { STT = "7", Name = "Nguyễn Văn Thành Phát", Date = "16/09/2021", Totals = "4.300.000 vnđ" });
            lstHistory.Items.Add(new { STT = "8", Name = "Nguyễn Đức Hòa", Date = "16/09/2021", Totals = "1.330.000 vnđ" });
        }

        private void lstHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
