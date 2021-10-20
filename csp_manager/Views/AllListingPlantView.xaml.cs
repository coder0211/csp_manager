﻿using CSChat.ViewModels;
using csp_manager.DataQuery;
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
    /// Interaction logic for AllListingPlantView.xaml
    /// </summary>
    public partial class AllListingPlantView : UserControl
    {
        QueryData QD = new QueryData();

        public delegate void LoadAllPlants();

        public AllListingPlantView()
        {
            InitializeComponent();

            //lstAllPlant.Items.Add(new { PlantName = "Hoa lan", NumberRemaining = 150000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 150000 });
            //lstAllPlant.Items.Add(new { PlantName = "Hoa hồng", NumberRemaining = 80000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 80000 });
            //lstAllPlant.Items.Add(new { PlantName = "Hoa lan", NumberRemaining = 150000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 150000 });
            //lstAllPlant.Items.Add(new { PlantName = "Hoa cúc", NumberRemaining = 150000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 150000 });
            //lstAllPlant.Items.Add(new { PlantName = "Hoa bưởi", NumberRemaining = 150000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 150000 });
            //lstAllPlant.Items.Add(new { PlantName = "Hoa hướng dương", NumberRemaining = 150000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 150000 });
            ListAllPlants();
        }

        public void ListAllPlants()
        {
            lstAllPlant.Items.Clear();
            foreach (var el in QD.GetPlants())
            {
                //string fPath = @"http://www.clipartkid.com/images/817/pic-of-german-flag-clipart-best-VkuN37-clipart.jpeg";
                string fPath = el.plant_img;
                //string fPath = Environment.CurrentDirectory + @"\Upload\" + el.plant_img;
                //if (!System.IO.File.Exists(fPath)) fPath = "pack://application:,,,/Res/Icons/ic_logo.png";
                if (string.IsNullOrEmpty(fPath)) fPath = "pack://application:,,,/Res/Icons/ic_logo.png";
                //else fPath = new Uri(fPath).AbsoluteUri;
                lstAllPlant.Items.Add(new { PlantID = el.plant_id, PlantImage = fPath, PlantName = el.plant_name, NumberRemaining = 0, NumberSell = 0, Supplier = el.plant_supplier_name, Price = el.plant_price });
            }
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            Window All = new PopUpAllView();
            All.ShowDialog();
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            Window infoItemAdd = new PlantInfoView();
            infoItemAdd.ShowDialog();
        }

        private void lstAllPlant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnEditInfo_Click(object sender, RoutedEventArgs e)
        {
            var plant_id = (int)((Button)sender).Tag;
            //MessageBox.Show("Plant ID: " + plant_id);
            Window edit = new EditInfoView(ListAllPlants, plant_id);
            edit.ShowDialog();
        }
    }
}
