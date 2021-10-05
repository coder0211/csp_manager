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
    /// Interaction logic for PopUpAllView.xaml
    /// </summary>
    public partial class PopUpAllView : Window
    {
        public PopUpAllView()
        {
            InitializeComponent();
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            btnFlower.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnForestTrees.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnFruitTrees.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnStocking.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
        }

        private void btnStocking_Click(object sender, RoutedEventArgs e)
        {
            btnFlower.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnForestTrees.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnFruitTrees.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnAll.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
        }

        private void btnFlower_Click(object sender, RoutedEventArgs e)
        {
            btnAll.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnForestTrees.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnFruitTrees.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnStocking.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
        }

        private void btnFruitTrees_Click(object sender, RoutedEventArgs e)
        {
            btnFlower.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnForestTrees.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnAll.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnStocking.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
        }

        private void btnForestTrees_Click(object sender, RoutedEventArgs e)
        {
            btnFlower.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnAll.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnFruitTrees.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnStocking.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
        }
    }
}
