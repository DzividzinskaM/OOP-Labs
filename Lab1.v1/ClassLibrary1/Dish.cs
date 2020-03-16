using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    internal enum TMeal
    {
        breakfast, 
        dinner, 
        supper
    }
    internal class Dish
    {
        internal string Name;
        internal double Price;
        internal string TypeMeal;

        internal Dish(string n, double p, string t)
        {
            Name = n;
            Price = p;
            TypeMeal = t;
        }
        
    }
}
