using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csp_manager
{
     public class Product
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public double Count { get; set; }
        public int Price { get; set; }
        public double Sold { get; set; }

        public Product(string image, string name, double count, int price, double sold)
        {
            Image = image;
            Name = name;
            Count = count;
            Price = price;
            Sold = sold;
        }


    }
}
