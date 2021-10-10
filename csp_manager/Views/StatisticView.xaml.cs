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
    //public class ViewModel : INotifyPropertyChanged
    //{
    //    private ObservableCollection<Line> lines;
    //    public ObservableCollection<Line> Lines
    //    {
    //        get
    //        {
    //            return this.lines;
    //        }
    //        set
    //        {
    //            if (this.lines != value)
    //            {
    //                this.lines = value;
    //                OnPropertyChanged("Lines");
    //            }
    //        }
    //    }
    //    public event PropertyChangedEventHandler PropertyChanged;
    //    private void OnPropertyChanged(string propertyName)
    //    {
    //        PropertyChangedEventHandler handler = this.PropertyChanged;
    //        if (handler != null)
    //        {
    //            handler(this, new PropertyChangedEventArgs(propertyName));
    //        }
    //    }
    //}
    public partial class StatisticView : UserControl, INotifyPropertyChanged
    {
        public class Line
        {
            public Point From { get; set; }
            public Point To { get; set; }
            public SolidColorBrush Stroke { get; set; }
            public float StrokeThickness { get; set; }
        }
        private ObservableCollection<Line> lines;
        public ObservableCollection<Line> Lines
        {
            get
            {
                return this.lines;
            }
            set
            {
                if (this.lines != value)
                {
                    this.lines = value;
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
                new Line { From = new Point(X_axis, Y_axis), To = new Point(X_axis, 210), Stroke = Brushes.Red, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 42, Y_axis), To = new Point(X_axis + 42, 235), Stroke = Brushes.Green, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 83, Y_axis), To = new Point(X_axis + 83, 220), Stroke = Brushes.Red, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 124, Y_axis), To = new Point(X_axis + 124, 250), Stroke = Brushes.Red, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 165, Y_axis), To = new Point(X_axis + 165, 270), Stroke = Brushes.Red, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 206, Y_axis), To = new Point(X_axis + 206, 280), Stroke = Brushes.Red, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 247, Y_axis), To = new Point(X_axis + 247, 240), Stroke = Brushes.Green, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 288, Y_axis), To = new Point(X_axis + 288, 230), Stroke = Brushes.Green, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 329, Y_axis), To = new Point(X_axis + 329, 225), Stroke = Brushes.Green, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 370, Y_axis), To = new Point(X_axis + 370, 230), Stroke = Brushes.Red, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 411, Y_axis), To = new Point(X_axis + 411, 225), Stroke = Brushes.Green, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 452, Y_axis), To = new Point(X_axis + 452, 300), Stroke = Brushes.Red, StrokeThickness = 3 }
            };
            //InitializeComponent();
            DataContext = this;

            setYear();
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
            setYear(1);
            ThongKe();
        }
        private void btnYearDown_Click(object sender, RoutedEventArgs e)
        {
            setYear(-1);
            ThongKe();
        }
        public void ThongKe()
        {
            int y = getYear();
            SolidColorBrush stk = y % 2 == 0 ? Brushes.Green : Brushes.Red;
            //SolidColorBrush stk = Brushes.Red;
            Lines = new ObservableCollection<Line>
            {
                new Line { From = new Point(X_axis, Y_axis), To = new Point(X_axis, 210), Stroke = stk, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 42, Y_axis), To = new Point(X_axis + 42, 235), Stroke = stk, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 83, Y_axis), To = new Point(X_axis + 83, 220), Stroke = stk, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 124, Y_axis), To = new Point(X_axis + 124, 250), Stroke = stk, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 165, Y_axis), To = new Point(X_axis + 165, 270), Stroke = stk, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 206, Y_axis), To = new Point(X_axis + 206, 280), Stroke = stk, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 247, Y_axis), To = new Point(X_axis + 247, 240), Stroke = stk, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 288, Y_axis), To = new Point(X_axis + 288, 230), Stroke = stk, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 329, Y_axis), To = new Point(X_axis + 329, 225), Stroke =stk, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 370, Y_axis), To = new Point(X_axis + 370, 230), Stroke = stk, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 411, Y_axis), To = new Point(X_axis + 411, 225), Stroke = stk, StrokeThickness = 3 },
                new Line { From = new Point(X_axis + 452, Y_axis), To = new Point(X_axis + 452, 300), Stroke = stk, StrokeThickness = 3 }
            };
            //DataContext = this;
        }
    }
}
