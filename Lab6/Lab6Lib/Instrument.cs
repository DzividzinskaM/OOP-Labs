using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6Lib
{
    public class Instrument
    {
        public int id { get; }
        public string name { get; }
        public int departmentId { get; }

        public Instrument(int id, string name, Department department) 
        {
            this.id = id;
            this.name = name;
            departmentId = department.id;
        }

        public Instrument(int id, string name, int departmentId)
        {
            this.id = id;
            this.name = name;
            this.departmentId = departmentId;
        }

    }
}
