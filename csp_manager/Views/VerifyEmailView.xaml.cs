﻿using System;
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
    /// Interaction logic for VerifyEmailView.xaml
    /// </summary>
    public partial class VerifyEmailView : UserControl
    {
        public VerifyEmailView()
        {
            InitializeComponent();
        }

        private void txtVerifyEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnVerify(object sender, RoutedEventArgs e)
        {
            Window mainWindow = Application.Current.MainWindow;
            mainWindow.Content = new HomeView();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Window mainWindow = Application.Current.MainWindow;
            mainWindow.Content = new LoginView();
        }
    }
}
