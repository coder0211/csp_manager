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
    public partial class AllListingPlantView : UserControl, INotifyPropertyChanged
    {

        private Visibility isShowLoading;

        public AllListingPlantView()
        {
            InitializeComponent();
            this.DataContext = this;
            isShowLoading = Visibility.Hidden;
            var products = GetProducts();
            if (products.Count > 0)
            {
                ListViewProducts.ItemsSource = products;
            }
        }

        private List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product("pack://application:,,,/Res/Images/image_demo.jpg","Hoa Hồng",1000,10000,1000),
                new Product("pack://application:,,,/Res/Images/image_demo.jpg","Hoa Hồng 1",2000,11000,2000),
                new Product("pack://application:,,,/Res/Images/image_demo.jpg","Hoa Hồng 2",3000,12000,3000),
                new Product("pack://application:,,,/Res/Images/image_demo.jpg","Hoa Hồng 3",4000,13000,4000),
                new Product("pack://application:,,,/Res/Images/image_demo.jpg","Hoa Hồng 4",5000,14000,5000),
                new Product("pack://application:,,,/Res/Images/image_demo.jpg","Hoa Hồng 5",6000,15000,6000)
            };
        }

        public Visibility IsShowLoading
        {
            get => isShowLoading; set
            {
                isShowLoading = value;
                OnPropertyChanged("isShowLoading");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
