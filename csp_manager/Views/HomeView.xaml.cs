﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        private String icCart;

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
        public string IcCart
        {
            get => icCart; set
            {
                icCart = value;
                OnPropertyChanged(nameof(IcCart));
            }
        }
        public int user_id;

        public HomeView(int user_id = 0)
        {
            InitializeComponent();
            this.user_id = user_id;
            this.DataContext = this;
            homeFrame.Content = new AllListingPlantView();
            IsShowDialog = Visibility.Hidden;
            IcPlant = "pack://application:,,,/Res/Icons/ic_plant_selected.png";
            IcStatistics = "pack://application:,,,/Res/Icons/ic_statistics.png";
            IcSetting = "pack://application:,,,/Res/Icons/ic_setting.png";
            IcHistory = "pack://application:,,,/Res/Icons/ic_history.png";
            IcCart = "pack://application:,,,/Res/Icons/ic_cart.png";

            var aTimer = new Timer(500);
            aTimer.Elapsed += new ElapsedEventHandler(Icon_Cart);
            aTimer.Enabled = true;
        }

        private void Icon_Cart(object source, ElapsedEventArgs e)
        {
            List<AllListingPlantView.ICart> p_arr = AllListingPlantView.p_arr;
            if (p_arr.Count > 0)
                IcCart = "pack://application:,,,/Res/Icons/ic_cart_color.png";
            else
                IcCart = "pack://application:,,,/Res/Icons/ic_cart.png";
        }

        public void Search(string s = "")
        {
            homeFrame.NavigationService.Navigate(new AllListingPlantView(s));
            btnStatistic.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnSetting.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnHistory.Foreground = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            btnLogout.Foreground = new SolidColorBrush(Color.FromRgb(211, 211, 211));
            IcPlant = "pack://application:,,,/Res/Icons/ic_plant_selected.png";
            IcStatistics = "pack://application:,,,/Res/Icons/ic_statistics.png";
            IcSetting = "pack://application:,,,/Res/Icons/ic_setting.png";
            IcHistory = "pack://application:,,,/Res/Icons/ic_history.png";
        }

        private bool isSearch = false;
        private void btnAllList_Click(object sender, RoutedEventArgs e)
        {
            Search();
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
            homeFrame.NavigationService.Navigate(new SettingView(user_id));
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
            homeFrame.NavigationService.Navigate(new HistoryView());
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
            Window Logout = new LogoutWarning();
            Logout.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text.Length >= 3)
            {
                Search(txtSearch.Text);
                isSearch = true;
            }
            else
            {
                if (isSearch)
                {
                    Search();
                    isSearch = false;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            //dialogFrame.Content = new CartView(this);
            //IsShowDialog = Visibility.Visible;

            List<AllListingPlantView.ICart> p_arr = AllListingPlantView.p_arr;
            if (p_arr.Count > 0)
            {
                Window Cart = new CartView(this);
                Cart.ShowDialog();
                if (Cart.DialogResult == true)
                    Search();
            }
            else
            {
                Window CartNoItem = new CartNoItemView(this);
                CartNoItem.ShowDialog();
            }
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            //dialogFrame.Content = new AddItemView(this);
            //IsShowDialog = Visibility.Visible;
            //Window Import = new AddItemView(this);
            //Import.ShowDialog();

            SplashScreenWindow splashScreen = new SplashScreenWindow();
            //splashScreen.Load(new AddItemView(this), "ShowDialog");
            splashScreen.Show();
            Task.Factory.StartNew(() =>
            {
                for (int i = 1; i <= 100; i++)
                {
                    System.Threading.Thread.Sleep(5);
                    splashScreen.Dispatcher.Invoke(() => splashScreen.Progress = i);
                }
                Dispatcher.Invoke(() =>
                {
                    var mainWindow = new AddItemView(this);
                    splashScreen.Close();
                    mainWindow.ShowDialog();
                    if (mainWindow.DialogResult == true)
                        Search();
                });
            });
        }
    }
}
