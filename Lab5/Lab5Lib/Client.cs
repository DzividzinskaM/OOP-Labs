using System;

namespace Lab5Lib
{
    public class Client
    {
        public int id { get; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int ITN { get; set; }
        public string phone { get; set; }

        public Client() { }

        public Client(string firstName, string lastName, int ITN, string phone)
        {
            id = ITN;
            this.firstName = firstName;
            this.lastName = lastName;
            this.ITN = ITN;
            this.phone = phone;
        }

        public Client(string firstName, string lastName, string ITN, string phone)
        {
          
            this.firstName = firstName;
            this.lastName = lastName;
            this.ITN = int.Parse(ITN);
            this.phone = phone;
            id = this.ITN;
        }
    }
}
