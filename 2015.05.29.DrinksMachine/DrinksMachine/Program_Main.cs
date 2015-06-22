using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace DrinksMachine
{
    class Program_Main
    {
        static void Main(string[] args)
        {
            //ShoppingLaboratory.startPurchase(); // before startPurchase was a static Method
 
            ShoppingLaboratory shoppingLaboratory = new ShoppingLaboratory();

            shoppingLaboratory.startPurchase(1, 0, 0, 0, 0, 0);

            //for (int i = 1; i <= 3; i++)
            //{
            //    shoppingLaboratory.startPurchase(i,0,0,0,0,0);
            //    Console.WriteLine();
            //    Console.WriteLine("------------------------------------------------\n");
            //}

            //shoppingLaboratory.startPurchase(0, 1, 1, 1, 1, 1);
            //shoppingLaboratory.startPurchase(0, 1, 1, 1, 2, 2);
            //shoppingLaboratory.startPurchase(0, 1, 1, 1, 3, 3);
            //shoppingLaboratory.startPurchase(0, 1, 1, 1, 4, 4);
            //shoppingLaboratory.startPurchase(0, 1, 1, 1, 1, 10);
            //shoppingLaboratory.startPurchase(0, 1, 1, 1, 1, 20);
            //shoppingLaboratory.startPurchase(0, 1, 1, 1, 1, 30);
            //shoppingLaboratory.startPurchase(0, 1, 1, 5, 10, 10);

            //shoppingLaboratory.startPurchase(0, 20, 20, 20, 20, 20);
            //shoppingLaboratory.startPurchase(0, 0, 20, 20, 20, 20);
            //shoppingLaboratory.startPurchase(0, 0,  0, 20, 20, 20);
            //shoppingLaboratory.startPurchase(0, 0,  0,  0, 20, 20);
            //shoppingLaboratory.startPurchase(0, 0,  0,  0,  0, 20);
            //shoppingLaboratory.startPurchase(0, 0, 0, 10, 10, 10);
            //shoppingLaboratory.startPurchase(0, 0, 0, 10, 30, 30);
            //shoppingLaboratory.startPurchase(0, 30, 30, 10, 30, 30);

            Console.ReadLine();
        }
       
    }
}
