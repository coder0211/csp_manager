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
using System.Windows.Shapes;

namespace csp_manager.Views
{
    /// <summary>
    /// Interaction logic for DetailsView.xaml
    /// </summary>
    public partial class DetailsView : Window
    {
        public DetailsView()
        {
            InitializeComponent();
        }

        private void txtCustomerName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtCustomerLocation_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtCustomerNote_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lstDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCloseDetails_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}