using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    internal class Supper : Meal
    {
        internal Supper(ref List<Dish> Menu)
        {
            SetRandomMenu(ref Menu);
        }
        internal override void SetRandomMenu(ref List<Dish> Menu)
        {
            Dish dish = new Dish("Chopped Kale Salad", 25);
            Menu.Add(dish);
            dish = new Dish("Avocado Salad", 22);
            Menu.Add(dish);
            dish = new Dish("Filet of Sole Oreganata", 35);
            Menu.Add(dish);
            dish = new Dish("Grilled Skirt Steak", 40);
            Menu.Add(dish);
            dish = new Dish("Gnocchi w/ Pesto", 36);
            Menu.Add(dish);
            dish = new Dish("Black/green tea", 18);
            Menu.Add(dish);
        }
    }
}
