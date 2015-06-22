using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksMachine
{
    class Purchase
    {
        // Machine m;
        // List<Drink> ld;
        // List<Coin> lc;
        // bool bool_purchaseDone;

        private Machine m;
        private List<Drink> ld;
        private List<Coin> lc;
        private bool bool_purchaseDone;

        private Drink drink;
        private Random rnd;

        //Constructor.
        public Purchase() 
        {
            //this.m = new Machine();
          
        }

        public void startMachine ()
        {
            this.m = new Machine();
            m.startMachine();           //in Machine, we make the 1°full of drinks and coins.

            this.rnd = new Random();
            this.ld = m.getLisProducts;
            this.lc = m.getListCoins;             
        }

        public void reStartMachine()
        {

            m.reStartMachine();   // we let all the stock in original numbers

            //this.rnd = new Random();
            this.ld = m.getLisProducts;
            this.lc = m.getListCoins;
        }


        public Machine getMachine
        {
            get { return m; }
            // { m = value; }
        }
        public Drink getDrink
        {
            get { return drink; }
         
        }

        public List<Drink> getListDrink
        {
            get { return ld; }
            // { m = value; }
        }

        public List<Coin> getListCoin
        {
            get { return lc; }
            // { m = value; }
        }

       


        public bool singlePurchase()
        {
            // Each time we intance Machine is a new machine with new drinks and coins
           

            Drink randomDrink = choseRandomProduct(ld);
            this.drink = randomDrink; // So we can read 
            // Console.WriteLine(randomDrink.Name);

            double moneyClientInsert = randomDoubleClientInsertForDrink(randomDrink, lc);
            bool_purchaseDone = m.Buyproduct(randomDrink, moneyClientInsert);

            //Console.WriteLine("bool_purchaseDone: {0} , product {1} , moneyClientInsert {2: 0.00}", 
            //                bool_purchaseDone, 
            //                randomDrink.Name,
            //                moneyClientInsert);

             //m.PrintEverything();
            //Console.WriteLine("---------------");
            //Console.ReadLine();

            return bool_purchaseDone;

        }

        public double randomDoubleClientInsertForDrink(Drink d, List<Coin> lc)
        {
            //2015.05.11 Alopez We generate a random double that is higher than the Drink.price and use
            // multiple od the coins that there are in lc. In this case 2, 1, 0.5, 0.2, 0.1.
            //We generate 3 Scenarios: 
            // a) 50% pays pays without digits everything in euros: ex 3.00, 4.00 etc
            // b) 25% pays the exact price of the drink
            // c) 25% pays 3.5, 4.5  etc.

            double moneyThatInsertClient = d.Price;

            // We asum that the 50% of the times the client pays the exact price of the product.
            Random rnd = new Random();
            // bool randomBool;
            // randomBool = rnd.Next(0, 2) > 0;

            if (rnd.Next(0, 2) > 0)
            {
                //The cliente pays drink.price + until to arrive a fix numbre of euro. Ex: 3eur, 2 euro etc

                moneyThatInsertClient = Math.Ceiling(moneyThatInsertClient);
                return moneyThatInsertClient;
               
            }

            else if (rnd.Next(0, 2) > 0)
            {
                // The cliente pay exact the price of the product
                return moneyThatInsertClient;
                
            }

            else
            {
                //The cliente pays drink.price + until to arrive a fix number of euro +0.50  Ex: 3.5e, 2.5euro etc
                moneyThatInsertClient = Math.Ceiling(moneyThatInsertClient) + (0.5);
                return moneyThatInsertClient;
            }

        }

        public void PrintEverything()
        {
            m.PrintEverything();
        }

        public Drink choseRandomProduct(List<Drink> ld)
        {
            // 2015.05.11 Alopez ld goes from 0 to ld.Count-1)
            // Console.WriteLine("ld[0].Name " + ld[0].Name);
            // Console.WriteLine("ld[ld.Count-1].Name " + ld[ld.Count - 1].Name);

             //rnd = null;
            //rnd = new Random();   //2015.05.15 Alopez wacht out to not repeat the seed creation. otherwise we dont get a random number 

            //int month = rnd.Next(1, 13); // creates a number between 1 and 12
            //this.rnd = new Random();
            int i = rnd.Next(0, ld.Count);

            //Console.WriteLine("Random number:" + i);
            return ld[i];
        }
    }
}
