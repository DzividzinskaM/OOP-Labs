using System;
using System.Collections.Generic;
using ClassLibrary1;

namespace Lab1.v1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("---------------/*BREAKFAST*/---------------");
            BreakfastBuilder breakfast = new BreakfastBuilder();
            ShowMenu(breakfast.BreakfastMenu);
            breakfast.SelectedDish = ChooseDish(breakfast.BreakfastMenu);
            breakfast.CreateCheck();
            ShowCheck(breakfast.BreakfastCheck);


            Console.WriteLine();


            Console.WriteLine("---------------/*DINNER*/---------------");
            DinnerBuilder dinner = new DinnerBuilder();
            ShowMenu(dinner.DinnerMenu);
            dinner.SelectedDish = ChooseDish(dinner.DinnerMenu);
            dinner.CreateCheck();
            ShowCheck(dinner.DinnerCheck);


            Console.WriteLine();


            Console.WriteLine("---------------/*SUPPER*/---------------");
            SupperBuider supper = new SupperBuider();
            ShowMenu(supper.SupperMenu);
            supper.SelectedDish = ChooseDish(supper.SupperMenu);
            supper.CreateCheck();
            ShowCheck(supper.SupperCheck);
        }



        static void ShowMenu(List<Dish> Menu)
        {
            Console.WriteLine("****************MENU****************");
            int count = 0;
            foreach(var value in Menu)
            {
                count++;
                Dish dish = value;
                Console.WriteLine($"{count}: {dish.Name}, {dish.Price}");
            }
        }

        static List<Dish> ChooseDish(List<Dish> Menu)
        {
            List<Dish> SelectedDishes = new List<Dish>();

            int answer = 1;

            while (answer != 0)
            {
                Console.WriteLine("Please, choose the dishes");
                Console.WriteLine("If you want to finish selecting, press '0'");

                answer = Convert.ToInt32(Console.ReadLine());
                if (answer < 0 || answer > Menu.Count)
                    Console.WriteLine("Your answer isn't correct");
                else if (answer == 0)
                    break;
                else
                {
                    SelectedDishes.Add(Menu[answer - 1]);
                }
            }
            return SelectedDishes;
        }

        static void ShowCheck(List<string> Check)
        {
            Console.WriteLine();
            Console.WriteLine("****************CHECK****************");
            foreach(var value in Check)
            {
                Console.WriteLine(value);
            }
        }
       
    }
}
