using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    internal class Menu
    {
        internal Menu()
        {
           
        }
        private List<Dish> Dishes = new List<Dish>();
        public void addDish(string name, double price, string typeMeal)
        {
            Dish dish = new Dish(name, price, typeMeal);
            Dishes.Add(dish);
        }

       internal List<Dish> getMenu()
       {
           return Dishes;
       }

    }
}
