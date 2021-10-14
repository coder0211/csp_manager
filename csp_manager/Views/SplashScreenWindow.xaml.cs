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
    /// Interaction logic for SplashScreenWindow.xaml
    /// </summary>
    public partial class SplashScreenWindow : Window
    {
        public SplashScreenWindow()
        {
            InitializeComponent();
        }

        public double Progress
        {
            get { return progressBar.Value; }
            set { progressBar.Value = value; }
        }
        public void Load(Window wd, string wt)
        {
            Show();
            Task.Factory.StartNew(() =>
            {
                for (int i = 1; i <= 100; i++)
                {
                    System.Threading.Thread.Sleep(5);
                    Dispatcher.Invoke(() => Progress = i);
                }
                Dispatcher.Invoke(() =>
                {
                    Close();
                    if (wt == "Show") wd.Show();
                    else if (wt == "ShowDialog") wd.ShowDialog();
                });
            });

        }
    }
}
