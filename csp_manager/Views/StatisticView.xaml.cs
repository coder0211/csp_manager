using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class StatisticView : UserControl
    {
        public class Line
        {
            public Point From { get; set; }
            public Point To { get; set; }
            public SolidColorBrush Stroke { get; set; }
            public float StrokeThickness { get; set; }
        }
        public ObservableCollection<Line> Lines { get; private set; }

        public StatisticView()
        {
            //InitializeComponent();
            // Trục X tăng dần theo công thức (i=0; i<N; i++): X_axis + i * 40 + i + 1 // Cột 12: X_axis + 11 * 40 + 11 + 1 = X_axis + 452 hehe.
            int X_axis = 178;
            int Y_axis = 440;
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

            InitializeComponent();
            DataContext = this;
        }
        //Line newLine(double x1, double x2, double y1, double y2, Brush brush)
        //{
        //    Line line = new Line();
        //    line.X1 = x1;
        //    line.X2 = x2;
        //    line.Y1 = y1;
        //    line.Y2 = y2;

        //    line.StrokeThickness = 1;
        //    line.Stroke = brush;

        //    // https://stackoverflow.com/questions/2879033/how-do-you-draw-a-line-on-a-canvas-in-wpf-that-is-1-pixel-thick
        //    line.SnapsToDevicePixels = true;
        //    line.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);

        //    base.Children.Add(line);

        //    return line;
        //}
        //public void DrawLineInt(PaintEventArgs e)
        //{

        //    // Create pen.
        //    Pen blackPen = new Pen(Color.Black, 3);

        //    // Create coordinates of points that define line.
        //    int x1 = 100;
        //    int y1 = 100;
        //    int x2 = 500;
        //    int y2 = 100;

        //    // Draw line to screen.
        //    e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        //}

    }
}
