using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace DrinksMachine
{
    class ShoppingLaboratory
    {
        bool bool_purchaseDone = true;
        
        int intNoStockDrinks = 0;
        int intNoStockCoins = 0;
        int CounterPurchase = 0;
        int CounterTest = 0;

        List<List<Coin>> listCoinTotal = new List<List<Coin>>();
        List<List<Drink>> listDrinkTotal = new List<List<Drink>>();
        DataTable myTable = new DataTable("theNameofmyTable");  // I didn't know which name to choose

        Machine m;
        Purchase p;

        public void startPurchase(int allCoins, int Euro2Coin, int Euro1Coin, int Euro05Coin, int Euro02Coin, int Euro01Coin)
        {
            CounterTest = intNoStockCoins = intNoStockDrinks = CounterPurchase = 0;

            myTable.Reset();
            myTable = createTableTotal(myTable);
            p = new Purchase();

            p.startMachine();             // We start the machine for the first Time
            m = p.getMachine;



            for (int i = 0; i < 10000; i++)  // We run the global  CounterTest
            {
                CounterTest += 1;

                p.reStartMachine();

                //2015.05.29 Alopez here we set the number of Coins to start
                // after reStartMachine we set all stockCoins to 0
                if (allCoins > 0)
                    m.increaseNumberStockCoinForAllCoins(allCoins);
                else m.increaseNumberStockCoinForSpecial(Euro2Coin, Euro1Coin, Euro05Coin, Euro02Coin, Euro01Coin);

                bool_purchaseDone = true;


                CounterPurchase = 0;
                //for( int j = 0; j< 2; j++)
                while (bool_purchaseDone == true)
                {
                    CounterPurchase += 1;

                    bool_purchaseDone = p.singlePurchase();
                    //print_testPurchase(bool_purchaseDone, p, CounterPurchase);
                }

                if (m.get_noChangeStock == true)
                {
                    intNoStockCoins += 1;
                    //Console.WriteLine("Test:{0} CounterPurchase:{1}, reasson nostockCoins:{2}, purchaseDone:{3}\n",
                    //                   CounterTest, CounterPurchase, m.get_noChangeStock, bool_purchaseDone);

                    //Console.WriteLine("Test:{0} CounterPurchase:{1}, reasson nostockCoins:{2}", CounterTest, CounterPurchase, m.get_noChangeStock);
                }

                if (m.get_noStockDrinks == true)
                {
                    intNoStockDrinks += 1;
                    //Console.WriteLine("Test:{0} CounterPurchase:{1}, reasson noStockDrinks:{2}, purchaseDone:{3}\n",
                    //                    CounterTest, CounterPurchase, m.get_noStockDrinks, bool_purchaseDone);

                    //Console.WriteLine("Test:{0} CounterPurchase:{1}, reasson noStockDrinks:{2}", CounterTest, CounterPurchase, m.get_noStockDrinks);
                }


                //m.PrintEverything();

                // Here we full both  List<List<Coin>> listCoinTotal;  List<List<Drink>> listDrinkTotal
                // but we use lateron one Table.
                listCoinTotal.Add(p.getListCoin);
                listDrinkTotal.Add(p.getListDrink);

                //myTable = createTableTotal(myTable, p.getListCoin, p.getListDrink, CounterTest, m.get_noStockDrinks , m.get_noChangeStock)
                //myTable [int CounterTest, int CounterPurchase, List<Coin> lc, List<Drink> ld,bool get_noStockDrinks, bool get_noChangeStock]
                myTable.Rows.Add(CounterTest, CounterPurchase, 
                                 p.getListCoin, p.getListDrink, 
                                 m.get_noChangeStock, m.get_noStockDrinks,
                                 intNoStockCoins, intNoStockDrinks);

            }  //ende 

            Console.WriteLine();
            Console.WriteLine("Final Test:{0}  [StopNotCoins:{1}  StopNotDrinks:{2}] ",
                                CounterTest, intNoStockCoins, intNoStockDrinks);

            //Console.WriteLine("InitialStockCoins: [2eur:{0}  1-eur:{1}  0.5eur:{2} 0.2eur:{3} 0.1eur:{4} ]", Euro2Coin, Euro1Coin, Euro05Coin, Euro02Coin, Euro01Coin);
            Console.WriteLine("InitialStockCoins: [{0} {1} {2} {3} {4}]", Euro2Coin, Euro1Coin, Euro05Coin, Euro02Coin, Euro01Coin);

            // printList_List_Coins(listCoinTotal);
            // printTableTotal(myTable); // 2015.05.18 Alopez We print here all the table


           
        }



        public  void print_testPurchase(bool b, Purchase p, int i)
        {
            Console.WriteLine();
            Console.WriteLine("{4}) Final Purchase:{0}, name:{1}, price:{2:0.00}, stock{3}",
                                b,
                                p.getDrink.Name,
                                p.getDrink.Price,
                                p.getDrink.Stock,
                                i);
            Console.WriteLine("------------\n");
        }

        public static void printList_List_Coins(List<List<Coin>> lcTotal)
        {
            //List<Coin> lc;

            foreach (List<Coin> lc in lcTotal)
            {
                //lc = listCoin;

                foreach (Coin c in lc)
                {
                    c.Druck();
                }

                // ******************  LinQ  ******************************************
                // 2015.05.29 just to use a real small example of LinQ to list the sotck
                //var cStock = from o in lc select o.Stock;
                ////cStock.ToList();

                //List<int> cStockList = new List<int>();
                //cStockList = cStock.ToList();  // to avoid the problem IEnumerable<string> into a List<string>.

                //foreach (int j in cStockList)
                //{
                //   Console.WriteLine(j);
                //}

                //var myCoin = from o in lc select o;
                //List<Coin> demoListCoin = new List<Coin>();
                //demoListCoin = myCoin.ToList();
                //foreach (Coin c in demoListCoin)
                //{
                //    c.Druck();
                //}

                Console.WriteLine();
            }
        }


        //public static DataTable createTableTotal(DataTable dt, int CounterTest, int CounterPurchase, 
        //                                        List<Coin> lc, List<Drink> ld, 
        //                                        bool get_noChangeStock, bool get_noStockDrinks)

        public  DataTable createTableTotal(DataTable dt)
        {
          /*0*/  dt.Columns.Add("CounterTest",      typeof(int));
          /*1*/  dt.Columns.Add("CounterPurchase",  typeof(int));
          /*2*/  dt.Columns.Add("ListCoin",         typeof(List<Coin>));
          /*3*/  dt.Columns.Add("ListDrink",        typeof(List<Drink>));
          /*4*/  dt.Columns.Add("noStockCoins",     typeof(bool));
          /*5*/  dt.Columns.Add("noStockDrinks",    typeof(bool));
          /*6*/  dt.Columns.Add("intNoStockCoins",  typeof(int));
          /*7*/  dt.Columns.Add("intNoStockDrinks", typeof(int));

            return dt;
        }



        // we dont use this method. We use direct   myTable.Rows.Add(blabla  etc) 
        //public static DataTable addRowTableTotal(DataTable dt, int CounterTest, int CounterPurchase,
        //                                        List<Coin> lc, List<Drink> ld,
        //                                        bool get_noStockDrinks, bool get_noChangeStock)
        
        //{


        //    dt.Rows.Add(CounterTest, CounterPurchase, lc, ld, get_noStockDrinks, get_noChangeStock);

        //    return dt;
        //}

        public void printTableTotal(DataTable dt)
        {
            // dt [int CounterTest, int CounterPurchase, List<Coin> lc, List<Drink> ld,bool get_noStockDrinks, bool get_noChangeStock]


            Console.WriteLine(" -------------  Print DataTable:{0} Columns:{1} ", dt.TableName, dt.Rows.Count);
            foreach (DataRow dataRow in dt.Rows)
            {
                //Console.WriteLine(dataRow[0].ToString, dataRow[1], dataRow[4].ToString, dataRow[5].ToString);
                Console.WriteLine("CounterTest:{0}  CounterPurchase:{1,3}" +
                                   " noStocCoins:{2} noStockDrinks:{3}\n" +
                                   "intNoStockCoins: {4}, intNoStockDrinks: {5}",
                                    dataRow[0], dataRow[1], dataRow[4], dataRow[5], dataRow[6], dataRow[7]);

                //foreach (List<Coin> lc in lcTotal)
                //if (dataRow[2].GetType = List<Coin> lc)
                //List<Coin> lc = (List<Coin>) dataRow[2];

                try
                {
                    foreach (Coin c in (List<Coin>)dataRow[2])
                    {
                        c.Druck();
                    }
                    Console.WriteLine();

                }
                catch
                {
                    Console.WriteLine("dataRow[2] bringt Values the are not Coin values");
                }


                try
                {
                    foreach (Drink d in (List<Drink>)dataRow[3])
                    {
                        d.Druck();
                    }
                    Console.WriteLine();

                }
                catch
                {
                    Console.WriteLine("dataRow[3] bringt values the are not Drink values");
                }

            }

        }

        //public static void PrintAllDrinkPurchase(DataTable dt)
        //{
        //    Console.WriteLine(" -------------  Print All drinks:{0} Columns:{1} ", dt.TableName, dt.Rows.Count);
        //    foreach (DataRow dataRow in dt.Rows)
        //    {

        //    }
        //}
    }
}
