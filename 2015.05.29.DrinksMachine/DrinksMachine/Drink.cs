using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksMachine
{
    public class Drink
    {

        private string nameProduct;
        private double priceProduct;
        private int stockProduct;

        public Drink(String name, double price, int stock)
        {
            this.nameProduct = name;
            this.priceProduct = price;
            this.stockProduct = stock;
        }

        public int Stock
        {
            get { return this.stockProduct; }
            set { this.stockProduct = value; }
        }

        public String Name
        {
            get { return this.nameProduct; }
            set { this.nameProduct = value; }
        }

        public double Price
        {
            get { return this.priceProduct; }
            set { this.priceProduct = value; }
        }

        public void Druck()
        {
            Console.WriteLine(String.Format("Drink : {0,9}  price:{1,3}  stock:{2,2}", this.nameProduct, this.priceProduct, this.stockProduct));
        }


        public void remove1unitStockProduct()
        {
            this.stockProduct = this.stockProduct - 1;

            
        }

      
    }
}
