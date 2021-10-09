using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
using csp_manager.DataQuery;

namespace csp_manager.Views
{
    /// <summary>
    /// Interaction logic for AddItemView.xaml
    /// </summary>
    public partial class AddItemView : Window
    {
        HomeView _homeView;

        public ObservableCollection<PlantTypeDTO> PlantType { get; private set; }
        public AddItemView(HomeView homeView)
        {
            QueryData a = new QueryData();
            PlantType = new ObservableCollection<PlantTypeDTO>(a.GetPlantType());
            //PlantType.ItemsSource = a.GetPlantType();
            //PlantType.DisplayMemberPath = "pt_name";

            _homeView = homeView;
            InitializeComponent();
            DataContext = this;
        }
        //public AddItemView(HomeView homeView)
        //{
        //    _homeView = homeView;
        //    InitializeComponent();
        //}

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

        }

        private void txtUnit_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

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
            this.Close();
        }
    }
}
