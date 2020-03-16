using System;
using Lib;

namespace lab1_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************BREAKFAST************");
            Order order = new Order("breakfast");
            SelectDish(order);
            ShowBillOnConsole(order);


            Console.WriteLine();

            Console.WriteLine("************DINNER************");
            order = new Order("dinner");
            SelectDish(order);
            ShowBillOnConsole(order);

            Console.WriteLine();

            Console.WriteLine("************SUPPER************");
            order = new Order("supper");
            SelectDish(order);
            ShowBillOnConsole(order);


        }

        static void ShowMenuOnConsole(Order order)
        {
            int count = 0;

            foreach(var value in order.GetMenu())
            {
                count++;
                Console.WriteLine($"{count}. {value.GetDishName()}");
            }
        }

        static void SelectDish(Order order)
        {
            ShowMenuOnConsole(order);

            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Choose the dish, that you want. If you want to get bill, please, press '0'");
                string Choise = Console.ReadLine().ToString();
                int NumberDish;

                if (!Int32.TryParse(Choise, out NumberDish) || NumberDish > order.GetMenu().Count)
                {
                    Console.WriteLine("Data isn't correct, please try again");
                    continue;
                }
                else
                {
                    if (NumberDish == 0)
                    {
                        flag = false;
                        return;
                    }
                    else
                    {
                        order.AddToBill(NumberDish-1);
                    }
                }
            }
        }

        static void ShowBillOnConsole(Order order)
        {
            foreach(var value in order.GetBill())
            {
                Console.WriteLine(value);
            }
        }
    }
}
