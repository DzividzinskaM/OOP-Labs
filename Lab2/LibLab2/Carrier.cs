using System;
using System.Collections.Generic;
using System.Text;

namespace LibLab2
{
    public class Carrier
    {
        private string CityFrom;
        private string CityTo;
        private List<Transport> CarrierByWays = new List<Transport>();
        private Dictionary<double, Transport> CarrierByDistance = new Dictionary<double, Transport>();
        private List<string> TransportCarrier = new List<string>();

        private RouteCreator routeCreator = new RouteCreator();
        private TransportCreator transportCreator = new TransportCreator();
        private Route route = new Route();

        
        public Carrier(string from, string to)
        {

            CityFrom = from;
            CityTo = to;

            DetermineCarrierByWay();
            DetermineCarrierByDistance();
            CreateCarrierList();
        }

        private void DetermineCarrierByWay()
        {
            
            if (!ExistsRoute())
            {
                Console.WriteLine("error");
                return;
            }
               
            // routeCreator.GetRoute();
            route = routeCreator.GetRoute(CityFrom, CityTo);
            if (route.GetAirway())
            {
                AddAirwaysTransport();
            }
            if (route.GetRailway())
            {
                AddRailwayTransport();
            }
            if (route.GetHighway())
            {
                AddHighwayTransport();
            }

        }

        private void DetermineCarrierByDistance()
        {
            foreach(var value in CarrierByWays)
            { 
                double time = route.GetDistance() / value.GetSpeed();
                time = Math.Round(time, 3);
                CarrierByDistance.Add(time, value);
            }
        }

        private bool ExistsRoute()
        {
            if(!routeCreator.GetRoutesMap().Exists(x=>x.GetCityFrom()==CityFrom) 
                || !routeCreator.GetRoutesMap().Exists(x=>x.GetCityTo()==CityTo))
            {
                return false;
            }
            return true;
        }

        private void AddAirwaysTransport()
        {
            foreach(var value in transportCreator.GetTransports())
            {
                if (value.GetTypeWay() == TransportWay.Airway.ToString())
                    CarrierByWays.Add(value);
            }
        }

        private void AddRailwayTransport()
        {
            foreach (var value in transportCreator.GetTransports())
            {
                if (value.GetTypeWay() == TransportWay.Railway.ToString())
                    CarrierByWays.Add(value);
            }
        }

        private void AddHighwayTransport()
        {
            foreach (var value in transportCreator.GetTransports())
            {
                if (value.GetTypeWay() == TransportWay.Highway.ToString())
                    CarrierByWays.Add(value);
            }
        }

        private void CreateCarrierList()
        {
            foreach(var value in CarrierByDistance)
            {
                TransportCarrier.Add(value.Value.GetNameTansport() + " " + value.Key + " hour");
            }
        }

       public List<string> GetCarrier()
        {
            return TransportCarrier;
        }
    }
}
