using CSChat.ViewModels;
using csp_manager.DataContext;
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

        public class ICart
        {
            public int Id { get; set; }
            public int Quantity { get; set; }
        }
        public static List<ICart> p_arr = new List<ICart>();
        private string search;

        public class Plant_
        {
            public plants p { get; set; }
            public string NumberSell { get; set; }
        }

        public AllListingPlantView(string search = "")
        {
            this.search = search;
            InitializeComponent();

            //lstAllPlant.Items.Add(new { PlantName = "Hoa lan", NumberRemaining = 150000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 150000 });
            //lstAllPlant.Items.Add(new { PlantName = "Hoa hồng", NumberRemaining = 80000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 80000 });
            //lstAllPlant.Items.Add(new { PlantName = "Hoa lan", NumberRemaining = 150000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 150000 });
            //lstAllPlant.Items.Add(new { PlantName = "Hoa cúc", NumberRemaining = 150000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 150000 });
            //lstAllPlant.Items.Add(new { PlantName = "Hoa bưởi", NumberRemaining = 150000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 150000 });
            //lstAllPlant.Items.Add(new { PlantName = "Hoa hướng dương", NumberRemaining = 150000, NumberSell = 2000, Supplier = "Vườn hoa nhà Hòa", Price = 150000 });

            List<plant_type> plant_Types = QD.GetPlantType();
            plant_Types.Insert(0, new plant_type { pt_id = 0, pt_name = "TẤT CẢ" });
            cbxPopUp.ItemsSource = plant_Types;
            cbxPopUp.DisplayMemberPath = "pt_name";
            cbxPopUp.SelectedValuePath = "pt_id";

            //ListAllPlants();
        }

        public void ListAllPlants(int plant_type = 0)
        {
            lstAllPlant.Items.Clear();
            foreach (var el in QD.GetPlants(search))
            {
                if (plant_type > 0 && el.plant_type_id != plant_type) continue;
                //string fPath = @"http://www.clipartkid.com/images/817/pic-of-german-flag-clipart-best-VkuN37-clipart.jpeg";
                //string fPath = el.plant_img;
                //string fPath = Environment.CurrentDirectory + @"\Upload\" + el.plant_img;
                //if (!System.IO.File.Exists(fPath)) fPath = "pack://application:,,,/Res/Icons/ic_logo.png";
                if (string.IsNullOrEmpty(el.plant_img)) el.plant_img = "pack://application:,,,/Res/Icons/ic_logo.png";
                //else fPath = new Uri(fPath).AbsoluteUri;
                //el.plant_img = fPath;
                //lstAllPlant.Items.Add(new { PlantID = el.plant_id, PlantImage = fPath, PlantName = el.plant_name, NumberRemaining = 0, NumberSell = 0, Supplier = el.plant_supplier_name, Price = el.plant_price });
                if (string.IsNullOrEmpty(el.plant_supplier_name)) el.plant_supplier_name = "ĐVQL CSPLANT";
                lstAllPlant.Items.Add(new Plant_ { p = el, NumberSell = "1230" });
                //MessageBox.Show(el.ToString());
            }
        }

        public void listAllPlants()
        {
            ListAllPlants();
        }

        private void cbxPopUp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = (int)cbxPopUp.SelectedValue;
            //MessageBox.Show(id.ToString());
            ListAllPlants(id);
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            var plant_id = (int)((Button)sender).Tag;

            Window infoItemAdd = new PlantInfoView(plant_id);
            infoItemAdd.ShowDialog();
            if (infoItemAdd.DialogResult == true)
            {
                //ICart x = p_arr.FindAll(y => y.id == plant_id);
                var x = p_arr.Find(delegate (ICart r)
                {
                    return r.Id == plant_id;
                });
                //MessageBox.Show(x.ToString());
                if (x == null)
                    p_arr.Add(new ICart { Id = plant_id, Quantity = PlantInfoView.GetQuantity });
                else x.Quantity = PlantInfoView.GetQuantity;
            }
        }

        private void lstAllPlant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnEditInfo_Click(object sender, RoutedEventArgs e)
        {
            var plant_id = (int)((Button)sender).Tag;
            //MessageBox.Show("Plant ID: " + plant_id);
            Window edit = new EditInfoView(listAllPlants, plant_id);
            edit.ShowDialog();
        }
    }
}
