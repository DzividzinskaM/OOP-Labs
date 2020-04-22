using System;
using System.Collections.Generic;
using System.Text;

namespace LibLab3
{
    public class History
    {
        public Stack<Memento> GameHistory { get; set; } 
        
        public History()
        {
            GameHistory = new Stack<Memento>();
        }
    }
}
