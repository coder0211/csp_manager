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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            homeFrame.Content = new AllListingPlantView();
        }

        private void btnAllList_Click(object sender, RoutedEventArgs e)
        {
            btnStatistic.Background = new SolidColorBrush();
            btnSetting.Background = new SolidColorBrush(); 
            homeFrame.Content = new AllListingPlantView();
        }
        private void btnStatistic_Click(object sender, RoutedEventArgs e)
        {
            btnAllList.Background = new SolidColorBrush();
            btnSetting.Background = new SolidColorBrush();
            homeFrame.Content = new StatisticView();
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            btnAllList.Background = new SolidColorBrush();
            btnStatistic.Background = new SolidColorBrush();
            homeFrame.Content = new SettingView();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
