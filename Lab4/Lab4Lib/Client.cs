using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4Lib
{
    public class Client
    {
        public int id { get; }
        public string firstName { get; }
        public string lastName { get; }
        public int ITN { get; }
        public string phone { get; }


        public Client(string firstName, string lastName, int ITN, string phone)
        {
            id = ITN;
            this.firstName = firstName;
            this.lastName = lastName;
            this.ITN = ITN;
            this.phone = phone;
        }



    }
}
