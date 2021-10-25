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
using System.Windows.Shapes;

namespace csp_manager.Views
{
    /// <summary>
    /// Interaction logic for ChangePassSuccessView.xaml
    /// </summary>
    public partial class ChangePassSuccessView : Window
    {
        public ChangePassSuccessView()
        {
            InitializeComponent();
        }

        private void btnOKPass_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
