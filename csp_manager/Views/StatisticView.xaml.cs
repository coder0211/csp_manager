using csp_manager.DataContext;
using csp_manager.DataQuery;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for StatisticView.xaml
    /// </summary>
    public partial class StatisticView : UserControl, INotifyPropertyChanged
    {
        Func f = new Func();

        public class Line
        {
            public Point From { get; set; }
            public Point To { get; set; }
            public SolidColorBrush Stroke { get; set; }
            public float StrokeThickness { get; set; }
            public string Total { get; set; }
        }
        private ObservableCollection<Line> lines;
        public ObservableCollection<Line> Lines
        {
            get => lines;
            set
            {
                if (lines != value)
                {
                    lines = value;
                    OnPropertyChanged("Lines");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // Trục X tăng dần theo công thức (i=0; i<N; i++): X_axis + i * 40 + i + 1 // Cột 12: X_axis + 11 * 40 + 11 + 1 = X_axis + 452 hehe.
        private int X_axis = 178;
        private int Y_axis = 440;

        public StatisticView()
        {
            InitializeComponent();
            Lines = new ObservableCollection<Line>
            {
                new Line { },
                new Line { },
                new Line { },
                new Line { },
                new Line { },
                new Line { },
                new Line { },
                new Line { },
                new Line { },
                new Line { },
                new Line { },
                new Line { }
            };
            //InitializeComponent();
            DataContext = this;
            setYear();
            ThongKe();
        }

        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            Task.Delay(5000).Wait();
        }

        private void setYear(int y = 0)
        {
            txtYear.Text = y == 0 ? DateTime.Now.Year.ToString() : (int.Parse(txtYear.Text) + y).ToString();
        }
        public int getYear()
        {
            return int.Parse(txtYear.Text);
        }
        private void btnYearUp_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.Now.Year > getYear())
            {
                setYear(1);
                ThongKe();
            }
        }
        private void btnYearDown_Click(object sender, RoutedEventArgs e)
        {
            setYear(-1);
            ThongKe();
        }
        public void ThongKe()
        {
            int y = getYear();
            //int m = DateTime.Now.Month;
            QueryData QD = new QueryData();

            SolidColorBrush stk = y % 2 == 0 ? Brushes.Green : Brushes.Red;
            //Lines = new ObservableCollection<Line>
            //{
            //    new Line { From = new Point(X_axis, Y_axis), To = new Point(X_axis, 210), Stroke = stk, StrokeThickness = 3 },
            //    new Line { From = new Point(X_axis + 42, Y_axis), To = new Point(X_axis + 42, 235), Stroke = stk, StrokeThickness = 3 },
            //    new Line { From = new Point(X_axis + 83, Y_axis), To = new Point(X_axis + 83, 220), Stroke = stk, StrokeThickness = 3 },
            //    new Line { From = new Point(X_axis + 124, Y_axis), To = new Point(X_axis + 124, 250), Stroke = stk, StrokeThickness = 3 },
            //    new Line { From = new Point(X_axis + 165, Y_axis), To = new Point(X_axis + 165, 270), Stroke = stk, StrokeThickness = 3 },
            //    new Line { From = new Point(X_axis + 206, Y_axis), To = new Point(X_axis + 206, 280), Stroke = stk, StrokeThickness = 3 },
            //    new Line { From = new Point(X_axis + 247, Y_axis), To = new Point(X_axis + 247, 240), Stroke = stk, StrokeThickness = 3 },
            //    new Line { From = new Point(X_axis + 288, Y_axis), To = new Point(X_axis + 288, 230), Stroke = stk, StrokeThickness = 3 },
            //    new Line { From = new Point(X_axis + 329, Y_axis), To = new Point(X_axis + 329, 225), Stroke =stk, StrokeThickness = 3 },
            //    new Line { From = new Point(X_axis + 370, Y_axis), To = new Point(X_axis + 370, 230), Stroke = stk, StrokeThickness = 3 },
            //    new Line { From = new Point(X_axis + 411, Y_axis), To = new Point(X_axis + 411, 225), Stroke = stk, StrokeThickness = 3 },
            //    new Line { From = new Point(X_axis + 452, Y_axis), To = new Point(X_axis + 452, 300), Stroke = stk, StrokeThickness = 3 }
            //};
            Lines = new ObservableCollection<Line>
            {
                new Line { },
                new Line { },
                new Line { },
                new Line { },
                new Line { },
                new Line { },
                new Line { },
                new Line { },
                new Line { },
                new Line { },
                new Line { },
                new Line { }
            };
            // Trục Y đi từ trên cao xuống thấp: 210 -> 440
            List<Income> Incomes = new List<Income>();
            List<invoices> inv = QD.GetInvoices(getYear());
            int inc_total = 0, inc_max = 0;
            for (int i = 0; i < 12; i++)
            {
                //int inc = QD.GetIncomes(y, i + 1);
                int inc = 0;
                foreach (var el in inv)
                {
                    if (el.invoice_created_at.Month == i + 1) inc += el.invoice_total;
                }
                Incomes.Add(new Income { Year = y, Month = i + 1, Total = inc });
                inc_total += inc;
                if (inc_max < inc) inc_max = inc;
            }
            txtTBT.Text = f.NumberToStr(inc_total / 12);
            txtTDT.Text = f.NumberToStr(inc_total);
            if (inc_total > 0)
                for (int i = 0; i < 12; i++)
                {
                    if (Incomes[i].Total == 0) continue;
                    double Y_axis_ = Y_axis - (Incomes[i].Total == inc_max ? 210 : Math.Round((double)Incomes[i].Total / inc_max * 230));
                    Lines[i] = new Line { From = new Point(X_axis + i * 40 + i + 1, Y_axis), To = new Point(X_axis + i * 40 + i + 1, Y_axis_), Stroke = stk, StrokeThickness = 3, Total = f.NumberToStr(Incomes[i].Total) };
                    //MessageBox.Show((i + 1) + "," + ((double)Incomes[i].Total / inc_max * 230));
                }
            //Lines[11] = new Line { From = new Point(X_axis + 11 * 40 + 11 + 1, Y_axis), To = new Point(X_axis + 11 * 40 + 11 + 1, 350), Stroke = stk, StrokeThickness = 3 };
            //Lines[10] = new Line { From = new Point(X_axis + 10 * 40 + 10 + 1, Y_axis), To = new Point(X_axis + 10 * 40 + 10 + 1, 350), Stroke = stk, StrokeThickness = 3 };
        }
    }
}
