using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksMachine
{
    public class Coin
    {
        //private ICoinTyp typeCoin;

        int stockCoin;
        String nameCoin;
        double priceCoin;
        //IMachine machine;

        public Coin (int stockCoin, string nameCoin, double priceCoin)
        {
            this.stockCoin = stockCoin;
            this.nameCoin = nameCoin;
            this.priceCoin = priceCoin;
        }

        public double Price
        {
            get { return priceCoin; }
            set { priceCoin = value; }
        }

        public string Name
        {
            get { return nameCoin; }
            set { nameCoin = value; }
        }

        public int Stock
        {
            get { return stockCoin; }
            set { stockCoin = value; }
        }

        public void Druck()
        {
            Console.WriteLine(String.Format("Coin  : {0,8}  value:{1,3}  Stock:{2,2}", this.nameCoin, this.priceCoin, this.stockCoin));
            //Console.WriteLine(String.Format("Product: {0,8} price:{1,3}, stock:{2,2}", this.nameProduct, this.priceProduct, this.stockProduct));
        }


        public void Remove1Coin()
        {
            this.stockCoin = this.stockCoin - 1;

            if (this.stockCoin == 0)
            {
                //Console.WriteLine("There is no more stock of this coin {0}", this.nameCoin);
            }
        
           
        }

        public void Insert1Coin()
        {
            this.stockCoin = this.stockCoin + 1;
        }

    }
}

