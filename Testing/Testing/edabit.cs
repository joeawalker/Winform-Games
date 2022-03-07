// Its possible to solve using some or all of these librarys.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program
{
    public class Smoothies
    {
        static Dictionary<string, string> prices = new Dictionary<string, string>()
        {
            { "Strawberries", "$1.50" },
            { "Banana", "$0.50" },
            { "Mango", "$2.50" },
            { "Blueberries", "$1.00" },
            { "Raspberries", "$1.00" },
            { "Apple", "$1.75" },
            { "Pineapple", "$3.50" }
        };

        // write your code here!
        public string[] ingredients;

        public Smoothies(string[] i)
        {
            ingredients = i;
        }

        public void GetCost()
        {
            Console.WriteLine(prices.ElementAt(1).Key);
        }

        public void GetPrice()
        {

        }

        public void GetName()
        {

        }
    }
}