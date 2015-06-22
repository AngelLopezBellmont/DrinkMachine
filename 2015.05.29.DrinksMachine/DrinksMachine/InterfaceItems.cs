using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace DrinksMachine
{

    public interface IAutomat
    {

        void startMachine();

        void AddCoin(Coin c, List<Coin> l);
        void AddDrink(Drink d, List<Drink> l);

        void insertCoin(int numberCoin, double valueEachCoin);          // if we want to insert stock of coins in the Machine.

        bool Buyproduct(Drink product, double moneyClientInsert);
        void InsertCoinsForPurchase(double moneyClientInsert);      //Transform into <Coin> the double  moneyClientInsert
        bool canWeReturnChangeInPruchase(double moneyClientInsert, double priceProduct);  // With the coins in List<Coin> can we return change?

        void changeBack(double moneyClientInsert, double priceProduct);

        DataTable listCoinsIntoDataTable(List<Coin> lc);    // we use this Methode for canWeReturnChangeInPruchase
        
        void PrintCoinList();
        void PrintDrinkList();
        void PrintEverything();
        void fullMachine_Drinks(List<Drink> d);     // Insert initial stock of drinks in List<Drink>
        void fullMachine_Coins(List<Coin> l);       // Insert initial stock of coins in List<Coin>

        void reStartMachine();           // restart machine to initial values to make a new purchase Demo

        //bool get_noStockDrinks;        // property bool that tell us if there is a purchase of a porduct with no more stock.
        //bool get_noChangeStock;        // property bool that tell us if there is a coin that we need,    with no more stock.
        //List<Coin> getListCoins;       // porperties con not be written in one interface.

      

    }  
}
