using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    internal class Breakfast : Meal
    {
        internal Breakfast(ref List<Dish> Menu)
        {
            SetRandomMenu(ref Menu);
        }
        internal override void SetRandomMenu(ref List<Dish> Menu)
        {
            Dish dish = new Dish("Omelet", 20);
            Menu.Add(dish);
            dish = new Dish("Boiled Egg", 30);
            Menu.Add(dish);
            dish = new Dish("Porridge", 45);
            Menu.Add(dish);
            dish = new Dish("Juice", 15);
            Menu.Add(dish);
            dish = new Dish("Green tea", 13);
            Menu.Add(dish);
            dish = new Dish("Black tea", 17);
            Menu.Add(dish);
        }
    }
}
