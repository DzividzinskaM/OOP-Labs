using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    class Check
    {
        private List<Dish> SelectedDish = new List<Dish>();
        public List<string> OrderCheck = new List<string>();
        private double TotalPrice;

        public Check(List<Dish> SD)
        {
            SelectedDish = SD;
            CreateCheck();
        }

        public void CreateCheck()
        {
            foreach (var value in SelectedDish)
            {
                string DishForCheck = value.Name + ' ' + value.Price;
                OrderCheck.Add(DishForCheck);
                TotalPrice += value.Price;
            }
            string PriceForCheck = "Total price:" + TotalPrice;
            OrderCheck.Add(PriceForCheck);
        }

    }
}
