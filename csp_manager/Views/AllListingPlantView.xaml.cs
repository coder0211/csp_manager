using CSChat.ViewModels;
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
       
        public AllListingPlantView()
        {
            InitializeComponent();
            lstAllPlant.Items.Add(new { PlantName = "Hoa lan", NumberRemaining = 150000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 150000 });
            lstAllPlant.Items.Add(new { PlantName = "Hoa hồng", NumberRemaining = 80000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 80000 });
            lstAllPlant.Items.Add(new { PlantName = "Hoa lan", NumberRemaining = 150000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 150000 });
            lstAllPlant.Items.Add(new { PlantName = "Hoa cúc", NumberRemaining = 150000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 150000 });
            lstAllPlant.Items.Add(new { PlantName = "Hoa bưởi", NumberRemaining = 150000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 150000 });
            lstAllPlant.Items.Add(new { PlantName = "Hoa hướng dương", NumberRemaining = 150000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 150000 });
        }
        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            Window All = new PopUpAllView();
            All.ShowDialog();
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lstAllPlant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
