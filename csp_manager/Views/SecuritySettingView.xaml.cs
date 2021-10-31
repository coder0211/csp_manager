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
    /// Interaction logic for SecuritySettingView.xaml
    /// </summary>
    public partial class SecuritySettingView : UserControl
    {
        private bool isMemorize;
        public bool IsMemorize { get => isMemorize; set => isMemorize = value; }
        public SecuritySettingView()
        {
            InitializeComponent();
        }

        private void btnMemorize_Click(object sender, RoutedEventArgs e)
        {
            //IsMemorize = !IsMemorize;
            //if (isMemorize == true)
            //{
            //    btnMemorize.Background = new SolidColorBrush(Color.FromRgb(255, 255, 0));
            //}

            //else
            //{
            //    btnMemorize.Background = new SolidColorBrush(Color.FromRgb(20, 20, 20));
            //}
        }
    }
}
