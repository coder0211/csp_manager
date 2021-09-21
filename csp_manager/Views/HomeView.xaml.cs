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

        public Visibility IsShowDialog
        {
            get => isShowDialog; set
            {
                isShowDialog = value; 
                OnPropertyChanged(nameof(IsShowDialog));
            }
        }

        public HomeView()
        {
            InitializeComponent();
            this.DataContext = this;
            homeFrame.Content = new AllListingPlantView();
            IsShowDialog = Visibility.Hidden;
            dialogFrame.Content = new AddItemView(this);
        }

        private void btnAllList_Click(object sender, RoutedEventArgs e)
        {
            btnStatistic.Background = new SolidColorBrush();
            btnSetting.Background = new SolidColorBrush();
            homeFrame.NavigationService.Navigate(new AllListingPlantView());
        }
        private void btnStatistic_Click(object sender, RoutedEventArgs e)
        {
            btnAllList.Background = new SolidColorBrush();
            btnSetting.Background = new SolidColorBrush();
            homeFrame.NavigationService.Navigate(new StatisticView());
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            btnAllList.Background = new SolidColorBrush();
            btnStatistic.Background = new SolidColorBrush();
            homeFrame.NavigationService.Navigate(new SettingView());
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            IsShowDialog = Visibility.Visible;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
