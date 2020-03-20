using System;
using System.Collections.Generic;
using LibLab2;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kyiv-Chernivtsi");
            Carrier Carriers = new Carrier("Kyiv", "Chernivtsi");
            ShowCarrierOnConsole(Carriers);

            Console.WriteLine();

            Console.WriteLine("Fastiv-Kyiv");
            Carriers = new Carrier("Fastiv", "Kyiv");
            ShowCarrierOnConsole(Carriers);

            Console.WriteLine();

            Console.WriteLine("Kyiv-New York");
            Carriers = new Carrier("Kyiv", "New York");
            ShowCarrierOnConsole(Carriers);


        }

        static void ShowCarrierOnConsole(Carrier carrier)
        {
            int count = 0;
            foreach (var value in carrier.GetCarrier())
            {
                count++;
                Console.WriteLine($"{count}. {value}");
            }
        }
    }
}
