using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Order
    {
        private List<Dish> Menu = new List<Dish>();
        private string typeMeal;

        public Order(string t)
        {
            if (t == "breakfast" || t == "dinner" || t == "supper")
            {

            }
           
        }

        public void SetRandomMenu()
        {
            
        }

       /* public List<Dish> getMenu()
        {
            return Menu;
        }*/

    }
}
