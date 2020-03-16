using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class SupperBuider : MealBuider
    {
        public List<Dish> SupperMenu = new List<Dish>();
        public List<Dish> SelectedDish = new List<Dish>();
        public List<string> SupperCheck = new List<string>();

        public SupperBuider()
        {
            CreateMenu();
        }

        public override void CreateMenu()
        {
            Dish dish = new Dish("Chopped Kale Salad", 25);
            SupperMenu.Add(dish);
            dish = new Dish("Avocado Salad", 22);
            SupperMenu.Add(dish);
            dish = new Dish("Filet of Sole Oreganata", 35);
            SupperMenu.Add(dish);
            dish = new Dish("Grilled Skirt Steak", 40);
            SupperMenu.Add(dish);
            dish = new Dish("Gnocchi w/ Pesto", 36);
            SupperMenu.Add(dish);
            dish = new Dish("Black/green tea", 18);
            SupperMenu.Add(dish);
        }

        public override void CreateCheck()
        {
            /*Check Order = new Check(SelectedDish);
            SupperCheck = Order.OrderCheck;*/
        }
    }
}
