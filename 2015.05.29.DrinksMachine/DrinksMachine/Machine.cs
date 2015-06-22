using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;


namespace DrinksMachine
{
    class Machine : IAutomat
    {
        Random rng = new Random();
        private List<Coin> listCoins;
        private List<Drink> listDrinks;



        private bool noStockDrinks;
        private bool noChangeStock;
        //private List<Coin> tempListCoins;

        public Machine()
        {
 
        }

         
        public void startMachine()
        {
            this.listCoins = null;
            this.listCoins = new List<Coin>();

            //this.tempListCoins = new List<Coin>();
            this.listDrinks = null;
            this.listDrinks = new List<Drink>();

            fullMachine_Coins(listCoins);
            fullMachine_Drinks(listDrinks);
        }

        public void reStartMachine()
        {
            this.listCoins = null;
            this.listCoins = new List<Coin>();

            this.listDrinks = null;
            this.listDrinks = new List<Drink>();

            fullMachine_Coins(listCoins);
            fullMachine_Drinks(listDrinks);

        }

        public bool get_noStockDrinks
        {
            get { return noStockDrinks; }
        }


        public bool get_noChangeStock
        {
            get { return noChangeStock; }
        }


        public List<Coin> getListCoins
        {
            get { return listCoins; }
        }

        public List<Drink> getLisProducts
        {
            get { return listDrinks; }
        }

        public void AddCoin(Coin c, List<Coin> listCoins)
        {
            listCoins.Add(c);
        }


        public void AddDrink(Drink d, List<Drink> listDrinks)
        {
            listDrinks.Add(d);
        }

        public void increaseNumberStockCoinForAllCoins(int numberCoin)
        {
            foreach (Coin c in listCoins)
            {
                    c.Stock += numberCoin;
                
            }
        }

        public void increaseNumberStockCoinForSpecial(int Euro2Coin, int Euro1Coin, int Euro05Coin, int Euro02Coin, int Euro01Coin)
        {
            insertCoin(Euro2Coin, 2.00);
            insertCoin(Euro1Coin, 1.00);
            insertCoin(Euro05Coin, 0.50);
            insertCoin(Euro02Coin, 0.20);
            insertCoin(Euro01Coin, 0.10);
        }

        public void insertCoin(int numberCoin, double priceCoin)
        {
            foreach (Coin c in listCoins)
            {
                if (c.Price == priceCoin)
                {
                    //c.getStockCoin  = c.getStockCoin + numberCoin;
                    c.Stock += numberCoin;
                }
            }
        }

        //public void Buyproduct(string name, double moneyClientInsert)
        public bool Buyproduct(Drink drink, double moneyClientInsert)
        {
            bool flag = false;
            //Console.WriteLine("{0}, price:{1} , paid:{2} ", drink.Name, drink.Price, moneyClientInsert);

            if (canWeReturnChangeInPruchase(moneyClientInsert, drink.Price) && drink.Stock > 0
                && moneyClientInsert >= drink.Price)
            {
                flag = true;

                //Console.WriteLine("Before insert Coins");
                //PrintCoinList();
                //Console.WriteLine("-----------------------");

                InsertCoinsForPurchase(moneyClientInsert);

                //Console.WriteLine("after insert Coins");
                //PrintCoinList();
                //Console.WriteLine("-----------------------");

                drink.remove1unitStockProduct();

                // We know we can givebacj change because we already control 
                // in canWeReturnChangeInPruchase(moneyClientInsert, drink.Price)
                changeBack(moneyClientInsert, drink.Price);

                //Console.WriteLine("after change back");
                //PrintCoinList();
                //Console.WriteLine("-----------------------");
            }

            else
            {
                flag = false;
                //Console.WriteLine();
                //Console.WriteLine(string.Format("No purchase. Stock {0} of {1} is {2:0.00} and the client paid {3:0.00}"
                //   , drink.Stock
                //   , drink.Name
                //   , drink.Price
                //   , moneyClientInsert));

                if (!canWeReturnChangeInPruchase(moneyClientInsert, drink.Price))
                {
                    this.noChangeStock = true;
                }

                if (drink.Stock == 0)
                {
                    this.noStockDrinks = true;
                }

            }

            return flag;
        }

# if true
        public bool canWeReturnChangeInPruchase(double moneyClientInsert, double priceProduct)
        {
            bool flag;

            //fullMachine_Coins(tempListCoins);
            //tempListCoins = listCoins;

            // I create and full the DataTable with a Methode:
            // public DataTable listCoinsIntoDataTable(List<Coin> lc)

            DataTable dtlc = listCoinsIntoDataTable(listCoins);

            double change = Math.Round(moneyClientInsert - priceProduct, 2);
            //Console.WriteLine();
            for (int i = 0; i < dtlc.Rows.Count; i++)
            {

                while ((double)dtlc.Rows[i][2] <= change && (int)dtlc.Rows[i][3] > 0)
                {
                    change = Math.Round(change - (double)dtlc.Rows[i][2], 2);
                    dtlc.Rows[i][3] = (int)dtlc.Rows[i][3] - 1;
                }
            }

            if (change.Equals(0)) flag = true;

            else
            {
                flag = false;

                //Console.WriteLine("We can not return change. Client insert {0:0.00} , price: {1:0.00} ",
                //    moneyClientInsert, priceProduct);
                //printDataTable(dtlc);
            }

            return flag;
        }

# endif
        public DataTable listCoinsIntoDataTable(List<Coin> lc)
        {
            DataTable table = new DataTable();
# if true
            table.Columns.Add("index", typeof(int));
            table.Columns.Add("name", typeof(String));
            table.Columns.Add("price", typeof(double));
            table.Columns.Add("stock", typeof(int));
# endif
            for (int i = 0; i < lc.Count; i++)
            {
                table.Rows.Add(i, lc[i].Name, lc[i].Price, lc[i].Stock);
                
            }

            return table;
        }

        public void printDataTable(DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //string value = row[3].ToString();
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    if (j == 3)
                        Console.Write("Stock: " + dt.Rows[i][3].ToString());
                    else
                        Console.Write(dt.Rows[i][j].ToString() + "  ");
                }
                Console.WriteLine();
            }
        }

        public void changeBack(double moneyClientInsert, double priceProduct)
        {

            double change = moneyClientInsert - priceProduct;
            change = Math.Round(change, 2);

            foreach (Coin c in getListCoins)
            {
                while (c.Price <= change && c.Stock > 0)
                {
                    change = change - c.Price;
                    change = Math.Round(change, 2);
                    c.Remove1Coin();
                }
            }

        }

        public void InsertCoinsForPurchase(double moneyClientInsert)
        // We generate a random combinations of coins that mach what the client pays.
        // Always looks for the smallest combinations of coins that fit with the double moneyClientInsert,
        // starting with the 2euro-> 1 euro -> 0.50  -> .... -> 0.10euro

        // To make a pseudo Random payment, what we do is that, we check if the cliente pays:
        // with 2 euro or not--> 50%,
        // with 1 euro or not--> 50%,
        // etc ---> and maybe he pays with all 0.10euro Coins.
        // In case the value of the coin fits with the price we want to get, 
        // The coin is inside the payment with one probability of 50%. 

        {
            //getListCoins.Count
            //Coin x = getListCoins.Min();
            //Console.WriteLine(x.Name + "" + x.Price);

            foreach (Coin c in getListCoins)
            {
                bool randomBool = rng.Next(0, 2) > 0;
                if (randomBool)
                {
                    while (c.Price <= moneyClientInsert)
                    {
                        moneyClientInsert = moneyClientInsert - c.Price;
                        moneyClientInsert = Math.Round(moneyClientInsert, 2);
                        c.Insert1Coin();
                    }
                }

                //if (c.Price.Equals(0.10) && moneyClientInsert > 0)
                if (c.Price.Equals(0.10) && moneyClientInsert > 0)
                {
                    while (c.Price <= moneyClientInsert)
                    {
                        moneyClientInsert = moneyClientInsert - c.Price;
                        moneyClientInsert = Math.Round(moneyClientInsert, 2);
                        c.Insert1Coin();
                    }
                }
            }

        }


        public void PrintCoinList()
        {
            foreach (Coin c in listCoins)
            {
                c.Druck();
                //Console.WriteLine();
            }
        }

        public void PrintDrinkList()
        {
            foreach (Drink d in listDrinks)
            {
                d.Druck();
                //Console.WriteLine();
            }
        }

        public void PrintEverything()
        {
            foreach (Coin c in listCoins)
            {
                c.Druck();
                // Console.WriteLine();
            }
            foreach (Drink p in listDrinks)
            {
                p.Druck();
            }
        }

        public void fullMachine_Coins(List<Coin> l)
        {
            this.noChangeStock = false;
            
            l.Add(new Coin(0, "c2euro", 2.00));
            l.Add(new Coin(0, "c1euro", 1.00));
            l.Add(new Coin(0, "c50cent", 0.50));
            l.Add(new Coin(0, "c20cent", 0.20));
            l.Add(new Coin(0, "c10cent", 0.10));

        }
        public void fullMachine_Drinks(List<Drink> d)
        {
             
            this.noStockDrinks = false;

            d.Add(new Drink("CocaCola", 2.5, 20));
            d.Add(new Drink("Fanta", 2.5, 20));
            d.Add(new Drink("Water 0,1", 1.8, 20));
            d.Add(new Drink("Water 0,3", 1.8, 20));
            d.Add(new Drink("Water 0,5", 1.8, 20));
            d.Add(new Drink("Water 1l", 1.8, 20));

            d.Add(new Drink("Beer 0.3", 3.9, 20));
            d.Add(new Drink("Beer 0.5", 3.9, 20));

            d.Add(new Drink("Sprite", 2.5, 20));
            d.Add(new Drink("Cafe Pure", 2.1, 20));
            d.Add(new Drink("Cafe milk", 2.1, 20));
            d.Add(new Drink("Capuchino", 2.1, 20));

            //listDrinks.Add(new Drink("CocaCola", 2.5, 20));
            //listDrinks.Add(new Drink("Fanta", 2.5, 20));
            //listDrinks.Add(new Drink("Water", 1.8, 20));
            //listDrinks.Add(new Drink("Bier", 3.9, 20));
            //listDrinks.Add(new Drink("Sprite", 2.5, 20));


            //listCoins.Add(new Coin(1, "c2euro", 2.00));
            //listCoins.Add(new Coin(1, "c1euro", 1.00));
            //listCoins.Add(new Coin(1, "c50cent", 0.50));
            //listCoins.Add(new Coin(1, "c20cent", 0.20));
            //listCoins.Add(new Coin(1, "c10cent", 0.10));

            //Product cocaCola = new Product("cocaCola", 2.5, 20);
            //Product fanta = new Product("fanta", 2.5, 20);
            //Product water = new Product("water", 1.8, 20);
            //Product bier = new Product("bier", 3.9, 20);
            //Product sprite = new Product("sprite", 2.5, 20);


            //Coin c10cent = new Coin(20, "c10cent", 0.10);
            //Coin c20cent = new Coin(20, "c20cent", 0.20);
            //Coin c50cent = new Coin(20, "c50cent", 0.50);
            //Coin c1euro = new Coin(20, "c1euro", 1.00);
            //Coin c2euro = new Coin(20, "c2euro", 2.00);

        }
    }
}
