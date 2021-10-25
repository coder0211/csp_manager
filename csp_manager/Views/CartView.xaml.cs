﻿using csp_manager.DataContext;
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
    /// Interaction logic for CartView.xaml
    /// </summary>
    public partial class CartView : Window
    {

        HomeView _homeView;

        private QueryData QD = new QueryData();
        private List<AllListingPlantView.ICart> p_arr = AllListingPlantView.p_arr;
        private Func f = new Func();
        class Plant_
        {
            public plants Plant { get; set; }
            public int Quantity { get; set; }
        }
        int TongTien = 0;

        public CartView(HomeView homeView)
        {
            _homeView = homeView;
            InitializeComponent();

            //lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });
            //lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });
            //lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });
            //lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });
            //lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });
            //lstCart.Items.Add(new { Name = "Hoa hồng", Quantity = "x50", Price = "1.750.000 vnđ" });

            LoadCart();
        }

        private void LoadCart()
        {
            lstCart.Items.Clear();
            int tongtien = 0;
            string s = "";
            foreach (var v in p_arr)
            {
                plants plant = QD.GetPlant(v.Id, out string err);
                s += v.Id + ",";
                lstCart.Items.Add(new Plant_ { Plant = plant, Quantity = v.Quantity });
                tongtien += (int)plant.plant_price * v.Quantity;
            }
            TongTien = tongtien;
            txtTongTien.Text = f.NumberToStr(tongtien);
            //MessageBox.Show(s);
        }

        private void TempBut_Click(object sender, RoutedEventArgs e)
        {
            _homeView.IsShowDialog = Visibility.Hidden;
        }

        private void txtCustomerName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtCustomerLocation_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtCustomerNote_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnDeleteCart_Click(object sender, RoutedEventArgs e)
        {
            Window deleteCart = new DeleteCartWaring();
            deleteCart.ShowDialog();
            if (deleteCart.DialogResult == true)
            {
                lstCart.Items.Clear();
                p_arr.Clear();
            }

        }
        private void btnContinuteBuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void btnComplete_Click(object sender, RoutedEventArgs e)
        {
            int count = lstCart.Items.Count;
            if (count > 0)
            {
                invoices invoice = new invoices();
                invoice.user_id = 0;
                invoice.customer_name = txtCustomerName.Text;
                invoice.customer_phone_number = txtPhoneNumber.Text;
                invoice.customer_address = txtCustomerLocation.Text;
                invoice.invoice_note = txtCustomerNote.Text;
                invoice.invoice_total = TongTien;
                invoice.invoice_created_at = DateTime.Now;
                int invoice_id = QD.PostInvoice(invoice, out string err);
                if (err != "") MessageBox.Show(err);
                if (invoice_id > 0)
                {
                    //QD.PostInvoiceDetail(new invoice_details { }, out err);
                    foreach (Plant_ el in lstCart.Items)
                    {
                        QD.PostInvoiceDetail(new invoice_details { invoice_id = invoice_id, plant_id = el.Plant.plant_id, plant_amount = el.Quantity }, out err);
                    }
                    Window Complete = new OrderSuccessView();
                    Complete.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa có sản phẩm nào trong giỏ hàng!");
                Close();
            }
        }

        private void lstCart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            Window deleteItem = new DeleteOneItemWarningView();
            bool? dialogResult = deleteItem.ShowDialog();
            //MessageBox.Show(dialogResult.ToString());
            if (deleteItem.DialogResult == true)
            {
                Button btn = (Button)sender;
                p_arr.Remove(p_arr.SingleOrDefault(x => x.Id == (int)btn.Tag));
                //lstCart.Items.Remove(btn.Tag);
                LoadCart();
            }
        }
    }
}
