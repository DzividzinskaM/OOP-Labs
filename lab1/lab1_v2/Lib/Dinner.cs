using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    internal class Dinner : Meal
    {
        internal Dinner(ref List<Dish> Menu)
        {
            SetRandomMenu(ref Menu);
        }
        internal override void SetRandomMenu(ref List<Dish> Menu)
        {
            Dish dish = new Dish("Tomato Soup With Roast Beef", 35);
            Menu.Add(dish);
            dish = new Dish("Bowties & Broccoli", 40);
            Menu.Add(dish);
            dish = new Dish("Upgraded Ramen", 37);
            Menu.Add(dish);
            dish = new Dish("Caesar salad", 25);
            Menu.Add(dish);
            dish = new Dish("Grilled chicken salad", 28);
            Menu.Add(dish);
            dish = new Dish("Apple juice", 12);
            Menu.Add(dish);
            dish = new Dish("Grapes juice", 12);
            Menu.Add(dish);
            dish = new Dish("Green/Black tea", 15);
            Menu.Add(dish);
        }
    }
}
