using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6Lib
{
    public class Department
    {
        public int id { get; }
        public string name { get; }
        public int managerId { get; }

        public Department(int id, string name, Employee manager)
        {
            this.id = id;
            this.name = name;
            this.managerId = manager.id;
        }

        public Department(int id, string name, int managerId)
        {
            this.id = id;
            this.name = name;
            this.managerId = managerId;
        }
        
    }   
}
