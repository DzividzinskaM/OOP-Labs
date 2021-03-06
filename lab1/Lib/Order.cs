﻿using System;
using System.Collections.Generic;

namespace Lib
{
    public enum MealType 
    {
        breakfast, 
        dinner, 
        supper
    }
    public class Order
    {
        private List<Dish> DishesMenu = new List<Dish>();
        private string Type;
        private List<string> Bill = new List<string>();
        private double TotalPrice = 0;
        public Order(string Mtype)
        {
            if(CheckType(Mtype) == true)
            {
                CreateMenu();
            }
            else
            {
                ShowError();
            }
        }

        private bool CheckType(string Mtype)
        {
            if(Mtype == MealType.breakfast.ToString() 
                || Mtype == MealType.dinner.ToString()
                || Mtype == MealType.supper.ToString())
            {
                Type = Mtype;
                return true;
            }
            else
            {
                return false;
            }
        }

        private string ShowError()
        {
            string Error = "Your type of meal isn't correct";
            return Error;
        }

        private void CreateMenu()
        {
            if(Type == MealType.breakfast.ToString())
            {
                Breakfast breakfast = new Breakfast(ref DishesMenu);
            }
            else if(Type == MealType.dinner.ToString())
            {
                Dinner dinner = new Dinner(ref DishesMenu);
            }
            else
            {
                Supper supper = new Supper(ref DishesMenu);
            }
        }

        public List<Dish> GetMenu()
        {
            return DishesMenu;
        }


        public void AddToBill(int NumberDish)
        {
            Dish dish = DishesMenu[NumberDish];
            Bill.Add(dish.GetDishName());
            TotalPrice += dish.GetPrice();
        }

        public List<string> GetBill()
        {
            Bill.Add("TOTAL PRICE: " + TotalPrice.ToString());
            return Bill;
        }
    }
}
