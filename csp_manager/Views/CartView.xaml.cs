﻿using csp_manager.DataContext;
using csp_manager.DataQuery;
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
    /// Interaction logic for CartView.xaml
    /// </summary>
    public partial class CartView : Window
    {

        HomeView _homeView;

        private QueryData QD = new QueryData();
        private List<int> p_arr = AllListingPlantView.p_arr;
        private Func f = new Func();

        public CartView(HomeView homeView)
        {
            _homeView = homeView;
            InitializeComponent();

            //lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });
            //lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });
            //lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });
            //lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });
            //lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });
            //lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });

            LoadCart();
        }

        private void LoadCart()
        {
            lstCart.Items.Clear();
            string s = "";
            foreach (int v in p_arr)
            {
                plants plant = QD.GetPlant(v, out string err);
                s += v + ",";
                string fPath = plant.plant_img;
                //if (string.IsNullOrEmpty(fPath)) fPath = "pack://application:,,,/Res/Icons/ic_logo.png";
                lstCart.Items.Add(new { PlantID = plant.plant_id, PlantImage = fPath, Name = plant.plant_name, Quantity = "x1", Price = f.NumberToStr((int)plant.plant_price) + " đ" });
            }
            //MessageBox.Show(s);
        }

        private void TempBut_Click(object sender, RoutedEventArgs e)
        {
            _homeView.IsShowDialog = Visibility.Hidden;
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

        private void btnDeleteCart_Click(object sender, RoutedEventArgs e)
        {
            Window deleteCart = new DeleteCartWaring();
            deleteCart.ShowDialog();
            if (deleteCart.DialogResult == true)
            {
                lstCart.Items.Clear();
                p_arr.Clear();
            }

        }
        private void btnContinuteBuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnComplete_Click(object sender, RoutedEventArgs e)
        {
            Window Complete = new OrderSuccessView();
            Complete.ShowDialog();
        }

        private void lstCart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            Window deleteItem = new DeleteOneItemWarningView();
            bool? dialogResult = deleteItem.ShowDialog();
            //MessageBox.Show(dialogResult.ToString());
            if (deleteItem.DialogResult == true)
            {
                Button btn = (Button)sender;
                p_arr.Remove((int)btn.Tag);
                //lstCart.Items.Remove(btn.Tag);
                LoadCart();
            }
        }
    }
}
