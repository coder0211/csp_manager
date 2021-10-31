using csp_manager.DataContext;
using csp_manager.DataQuery;
using csp_manager.UploadImage;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static csp_manager.Views.AllListingPlantView;

namespace csp_manager.Views
{
    /// <summary>
    /// Interaction logic for EditInfoView.xaml
    /// </summary>
    public partial class EditInfoView : Window
    {
        Func f = new Func();
        //UpImgLocal upImg = new UpImgLocal();
        Imgur upImg = new Imgur();

        QueryData QD = new QueryData();
        private plants plant;

        public LoadAllPlants loadAllPlants;

        public ObservableCollection<plant_type> PlantType { get; private set; }
        public plant_type PlantTypeDefault { get; private set; }

        public EditInfoView(LoadAllPlants loadAll, int plant_id = 0)
        {
            List<plant_type> b = QD.GetPlantType();

            InitializeComponent();

            plant = QD.GetPlant(plant_id, out string err);

            cbxType.ItemsSource = b;
            cbxType.DisplayMemberPath = "pt_name";
            cbxType.SelectedValuePath = "pt_id";
            //cbxType.SelectedIndex = 1;
            cbxType.SelectedValue = plant.plant_type_id;

            txtNamePlant.Text = plant.plant_name;
            txtEditQuantity.Text = Convert.ToString(plant.plant_amount);
            txtEditPrice.Text = Convert.ToString(plant.plant_price);
            txtEditNote.Text = plant.plant_note;
            txtEditSupplier.Text = plant.plant_supplier_name;
            txtEditLocation.Text = plant.plant_supplier_address;
            if (!string.IsNullOrEmpty(plant.plant_img))
            {
                imgUpload.Source = new BitmapImage(new Uri(plant.plant_img));
                imgUpload.Width = double.NaN;
                imgUpload.Height = double.NaN;
            }
            loadAllPlants = loadAll;
        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            //this.MyImageSource = new BitmapImage(...); //you change source of the Image
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgUpload.Source = new BitmapImage(new Uri(op.FileName));
                imgUpload.Width = double.NaN;
                imgUpload.Height = double.NaN;
            }
        }

        private void txtNamePlant_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtEditQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtEditQuantity.Text = Regex.Replace(txtEditQuantity.Text, "[^0-9]+", "");
        }

        private void txtEditUnit_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtEditPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtEditPrice.Text = Regex.Replace(txtEditPrice.Text, "[^0-9]+", "");
        }

        private void txtEditSupplier_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtEditLocation_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtEditNote_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnEditDelete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEditComplete(object sender, RoutedEventArgs e)
        {
            if (txtNamePlant.Text == "")
            {
                MessageBox.Show("Tên sản phẩm không được trống!");
                return;
            }

            bool result = int.TryParse(cbxType.SelectedValue.ToString(), out int pt_id);
            plant.plant_type_id = pt_id;

            plant.plant_name = txtNamePlant.Text;

            result = int.TryParse(txtEditQuantity.Text, out int plant_amount);
            plant.plant_amount = result ? plant_amount : 0;

            result = int.TryParse(txtEditPrice.Text, out int plant_price);
            plant.plant_price = result ? plant_price : 0;

            plant.plant_note = txtEditNote.Text;
            plant.plant_supplier_name = txtEditSupplier.Text;
            plant.plant_supplier_address = txtEditLocation.Text;

            if (plant.plant_img != imgUpload.Source.ToString())
            {
                bool qwe = upImg.Delete(plant.plant_img);
                //MessageBox.Show(qwe.ToString());
                plant.plant_img = upImg.Upload(imgUpload.Source.ToString());
            }
            bool tesUpdate = QD.UpdatePlant(plant, out _);
            if (tesUpdate)
            {
                plant = null;
                f = null;
                upImg = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Close();
                Window editComplete = new EditSuccessView();
                editComplete.ShowDialog();
                loadAllPlants();
            }
            else
            {
                MessageBox.Show("Không thể cập nhật sản phẩm!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Window deleteItem = new DeleteOneItemWarningView();
            deleteItem.ShowDialog();
            if (deleteItem.DialogResult == true)
            {
                if (QD.GetQuantitySold(plant.plant_id) == 0)
                {
                    if (plant.plant_img.Length > 0)
                    {
                        upImg.Delete(plant.plant_img);
                    }
                    QD.DeletePlant(plant.plant_id);
                    Close();
                    loadAllPlants();
                }
                else
                {

                }
            }
        }
    }
}
