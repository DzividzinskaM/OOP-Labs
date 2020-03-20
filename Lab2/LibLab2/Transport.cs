using System;
using System.Collections.Generic;
using System.Text;

namespace LibLab2
{
    internal enum TransportWay
    {
        Airway,
        Highway, 
        Railway
    }
    internal class Transport
    {
        private string NameTransport;
        private double Speed;
        private string TypeWay;

        internal Transport(string name, double s, string tway)
        {
            NameTransport = name;
            Speed = s;
            TypeWay = tway;
        }

        internal Transport()
        {

        }

        internal string GetNameTansport()
        {
            return NameTransport;
        }

        internal string GetTypeWay()
        {
            return TypeWay;
        }

        internal double GetSpeed()
        {
            return Speed;
        }
    }
}
