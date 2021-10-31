using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using csp_manager.DataContext;
using csp_manager.DataQuery;
using csp_manager.UploadImage;
using Microsoft.Win32;
using static csp_manager.Views.AllListingPlantView;

namespace csp_manager.Views
{
    /// <summary>
    /// Interaction logic for AddItemView.xaml
    /// </summary>
    public partial class AddItemView : Window
    {
        HomeView _homeView;
        QueryData QD = new QueryData();

        public ObservableCollection<plant_type> PlantType { get; private set; }
        public plant_type PlantTypeDefault { get; private set; }

        public AddItemView(HomeView homeView)
        {
            List<plant_type> b = QD.GetPlantType();
            //PlantType = new ObservableCollection<plant_type>(b);
            //PlantTypeDefault = PlantType.FirstOrDefault();

            _homeView = homeView;
            InitializeComponent();
            //DataContext = this;

            cbxType.ItemsSource = b;
            cbxType.DisplayMemberPath = "pt_name";
            cbxType.SelectedValuePath = "pt_id";
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

                //Imgur a = new Imgur();
                //string b = a.Upload(op.FileName);
                //MessageBox.Show("Test upload:\n" + b, "My App");

                //Directory.CreateDirectory(Environment.CurrentDirectory + @"\Upload");
                //string fileName = System.IO.Path.GetFileName(op.FileName);
                //string destFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"Upload\", fileName);
                //MessageBox.Show(op.FileName + "\n" + destFile);
                //File.Copy(op.FileName, destFile, true);
            }
        }

        private void txtSupplier_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNote_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtLocation_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtQuantity.Text = Regex.Replace(txtQuantity.Text, "[^0-9]+", "");
        }

        private void txtUnit_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtPrice.Text = Regex.Replace(txtPrice.Text, "[^0-9]+", "");
        }

        private void txtType_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCompleted_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Tên sản phẩm không được trống!");
                return;
            }

            Func f = new Func();
            //UpImgLocal upImg = new UpImgLocal();
            Imgur upImg = new Imgur();
            plants plant = new plants();

            bool result = int.TryParse(cbxType.SelectedValue.ToString(), out int pt_id);
            plant.plant_type_id = pt_id;

            plant.plant_name = txtName.Text;

            result = int.TryParse(txtQuantity.Text, out int plant_amount);
            plant.plant_amount = result ? plant_amount : 0;



            result = int.TryParse(txtPrice.Text, out int plant_price);
            plant.plant_price = result ? plant_price : 0;

            plant.plant_note = txtNote.Text;
            plant.plant_supplier_name = txtSupplier.Text;
            plant.plant_supplier_address = txtLocation.Text;
            plant.plant_created_at = DateTime.Now;

            //MessageBox.Show("Tên cây:" + plant.plant_name + "\nSố lượng:" + plant.plant_amount + "\nĐơn vị:" + plant.plant_unit + "\nGiá:" + f.NumberToStr((int)plant.plant_price) + "\nLoại cây: " + pt_id + "_" + cbxType.Text);
            //MessageBox.Show("Img: " + imgUpload.Source.ToString());

            int testInsert = QD.PostPlant(plant, out string err);
            if (testInsert > 0)
            {
                //string testUpImg = upImg.Upload(imgUpload.Source.ToString(), "plant_" + testInsert);
                string testUpImg = upImg.Upload(imgUpload.Source.ToString());
                plant.plant_img = testUpImg;
                QD.UpdatePlant(plant, out _);
                //MessageBox.Show("testUpImg: " + testUpImg);
                if (testUpImg != "")
                {
                    MessageBox.Show("Thêm sản phẩm thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm thành công nhưng không thể cập nhật ảnh! Vui lòng cập nhật sau.");
                }
                DialogResult = true;
                Close();
            }
            else
            {
                DialogResult = false;
                MessageBox.Show("Có lỗi xảy ra!");
            }
        }
    }
}
