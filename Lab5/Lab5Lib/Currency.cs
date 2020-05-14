using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5Lib
{
    public class Currency
    {
        public string name { get; set; }
        public double buying { get; set; }
        public double sellling { get; set; }

        public Currency(string name, double buying, double selling)
        {
            this.name = name;
            this.buying = buying;
            this.sellling = selling;
        }
    }
}
