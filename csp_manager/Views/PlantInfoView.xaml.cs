using csp_manager.DataContext;
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
    /// Interaction logic for PlantInfoView.xaml
    /// </summary>
    public partial class PlantInfoView : Window
    {
        QueryData QD = new QueryData();
        Func f = new Func();
        private plants plant;

        public PlantInfoView(int plant_id)
        {
            InitializeComponent();

            plant = QD.GetPlant(plant_id, out string err);
            plant_name.Text = plant.plant_name;
            plant_amount.Text = plant.plant_amount.ToString();
            plant_price.Text = f.NumberToStr((int)plant.plant_price);
            plant_supplier_name.Text = "ĐVQL CSPLANT";
            plant_note.Text = plant.plant_note;
            imgUpload.Source = new BitmapImage(new Uri(string.IsNullOrEmpty(plant.plant_img) ? "pack://application:,,,/Res/Icons/ic_logo.png" : plant.plant_img));
            imgUpload.Width = double.NaN;
            imgUpload.Height = double.NaN;
            plant_sold.Text = f.NumberToStr(QD.GetQuantitySold(plant_id));
        }

        public static int GetQuantity;

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            GetQuantity = int.Parse(txtQuantity.Text == "" ? "1" : txtQuantity.Text);
            Close();
        }

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool err = int.TryParse(txtQuantity.Text, out int q);
            if (!err) txtTempPrice.Text = "Số lượng phải là số!";
            else txtTempPrice.Text = f.NumberToStr((int)(plant.plant_price * q));
        }

        private void txtTempPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
