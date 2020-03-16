using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    internal abstract class Meal
    {
        internal abstract void SetRandomMenu(ref List<Dish> Menu);
    }
}
