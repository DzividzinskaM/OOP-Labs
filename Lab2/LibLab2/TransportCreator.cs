using System;
using System.Collections.Generic;
using System.Text;

namespace LibLab2
{
    internal class TransportCreator
    {
        private List<Transport> Transports = new List<Transport>();

        internal TransportCreator()
        {
            CreateTransports();
        }

        private void CreateTransports()
        {
            Transport transport = new Transport("Taxi", 75, TransportWay.Highway.ToString());
            Transports.Add(transport);
            transport = new Transport("Route taxi", 60, TransportWay.Highway.ToString());
            Transports.Add(transport);
            transport = new Transport("Plane", 870, TransportWay.Airway.ToString());
            Transports.Add(transport);
            transport = new Transport("Train", 90, TransportWay.Railway.ToString());
            Transports.Add(transport);
        }

        internal List<Transport> GetTransports()
        {
            return Transports;
        }

    }
}
