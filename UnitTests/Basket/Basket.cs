using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketNS
{
    public class Basket
    {
        private string customer;
        private List<String> contents;
        private double price;

        private Basket()
        {
            contents = new List<string>();
        }

        public Basket(string cus, List<String> con, double p)
        {
            customer = cus;
            contents = con;
            price = p;
        }

        public string Customer
        {
            get { return customer; }
        }

        public List<String> Contents
        {
            get { return contents; }
        }
        public double Price
        {
            get { return price; }
        }

        public void AddProduct(string product, double productPrice)
        {
            contents.Add(product);
            price += productPrice;
        }

        public void DeleteProduct(string product, double productPrice)
        {
             contents.Remove(product);
             price -= productPrice;
        }

        public double CountDiscountPrice(double percent)
        {
            double discount = percent / 100.0;
            return price - price * discount;
        }


    }
}
