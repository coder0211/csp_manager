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
