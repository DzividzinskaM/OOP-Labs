using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class Dish
    {
        private string DishName;
        private double DishPrice;

        public Dish(string n, double p)
        {
            DishName = n;
            DishPrice = p;
        }

        public string GetDishName()
        {
            return DishName + " " + DishPrice.ToString(); 
        }

        public double GetPrice()
        {
            return DishPrice;
        }
        
    }
}
