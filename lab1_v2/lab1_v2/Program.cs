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
            ShowMenu(order);

            Console.WriteLine();

            Console.WriteLine("************DINNER************");
            order = new Order("dinner");
            ShowMenu(order);

            Console.WriteLine();

            Console.WriteLine("************SUPPER************");
            order = new Order("supper");
            ShowMenu(order);



        }

        static void ShowMenu(Order order)
        {
            int count = 0;

            foreach(var value in order.GetMenu())
            {
                count++;
                Console.WriteLine($"{count}. {value.GetDishName()}");
            }
        }
    }
}
