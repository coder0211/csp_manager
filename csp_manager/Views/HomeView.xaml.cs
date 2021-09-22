using System;
using System.Collections.Generic;
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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl, INotifyPropertyChanged
    {
        private Visibility isShowDialog;
        private String icPlant;
        private String icStatistics;
        private String icSetting;
        private String icHistory;

        public Visibility IsShowDialog
        {
            get => isShowDialog; set
            {
                isShowDialog = value;
                OnPropertyChanged(nameof(IsShowDialog));
            }
        }

        public string IcPlant
        {
            get => icPlant; set
            {
                icPlant = value;
                OnPropertyChanged(nameof(IcPlant));
            }
        }
        public string IcStatistics
        {
            get => icStatistics; set
            {
                icStatistics = value;
                OnPropertyChanged(nameof(IcStatistics));
            }
        }
        public string IcSetting
        {
            get => icSetting; set
            {
                icSetting = value;
                OnPropertyChanged(nameof(IcSetting));
            }
        }
        public string IcHistory
        {
            get => icHistory; set
            {
                icHistory = value;
                OnPropertyChanged(nameof(IcHistory));
            }
        }       

        public HomeView()
        {
            InitializeComponent();
            this.DataContext = this;
            homeFrame.Content = new AllListingPlantView();
            IsShowDialog = Visibility.Hidden;
            dialogFrame.Content = new AddItemView(this);
            IcPlant = "pack://application:,,,/Res/Icons/ic_plant_selected.png";
            IcStatistics = "pack://application:,,,/Res/Icons/ic_statistics.png";
            IcSetting = "pack://application:,,,/Res/Icons/ic_setting.png";
            IcHistory = "pack://application:,,,/Res/Icons/ic_history.png";
        }

        private void btnAllList_Click(object sender, RoutedEventArgs e)
        {
            homeFrame.NavigationService.Navigate(new AllListingPlantView());
            btnStatistic.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnSetting.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnHistory.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));           
            btnLogout.Foreground = new SolidColorBrush(Color.FromRgb(211, 211, 211));
            IcPlant = "pack://application:,,,/Res/Icons/ic_plant_selected.png";
            IcStatistics = "pack://application:,,,/Res/Icons/ic_statistics.png";
            IcSetting = "pack://application:,,,/Res/Icons/ic_setting.png";
            IcHistory = "pack://application:,,,/Res/Icons/ic_history.png";
        }

        private void btnStatistic_Click(object sender, RoutedEventArgs e)
        {
            homeFrame.NavigationService.Navigate(new StatisticView());
            btnAllList.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnSetting.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnHistory.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnLogout.Foreground = new SolidColorBrush(Color.FromRgb(211, 211, 211));
            IcPlant = "pack://application:,,,/Res/Icons/ic_plant.png";
            IcStatistics = "pack://application:,,,/Res/Icons/ic_statistics_selected.png";
            IcSetting = "pack://application:,,,/Res/Icons/ic_setting.png";
            IcHistory = "pack://application:,,,/Res/Icons/ic_history.png";
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            homeFrame.NavigationService.Navigate(new SettingView());
            btnAllList.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnStatistic.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnHistory.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnLogout.Foreground = new SolidColorBrush(Color.FromRgb(211, 211, 211));
            IcPlant = "pack://application:,,,/Res/Icons/ic_plant.png";
            IcStatistics = "pack://application:,,,/Res/Icons/ic_statistics.png";
            IcSetting = "pack://application:,,,/Res/Icons/ic_setting_selected.png";
            IcHistory = "pack://application:,,,/Res/Icons/ic_history.png";
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            homeFrame.NavigationService.Navigate(new SettingView());
            btnAllList.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnStatistic.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnSetting.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnLogout.Foreground = new SolidColorBrush(Color.FromRgb(211, 211, 211));
            IcPlant = "pack://application:,,,/Res/Icons/ic_plant.png";
            IcStatistics = "pack://application:,,,/Res/Icons/ic_statistics.png";
            IcSetting = "pack://application:,,,/Res/Icons/ic_setting.png";
            IcHistory = "pack://application:,,,/Res/Icons/ic_history_selected.png";
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            
            //btnAllList.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            //btnStatistic.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            //btnHistory.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            //btnSetting.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            IsShowDialog = Visibility.Visible;
        }
    }
}
