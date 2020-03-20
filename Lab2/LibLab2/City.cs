using System;
using System.Collections.Generic;

namespace LibLab2
{
    internal class City
    {
        private string CityName;
        private List<string> CityKey = new List<string>();
        private Dictionary<string, double> Distance = new Dictionary<string, double>();
        private Dictionary<string, bool> AvailabilityOfHighway = new Dictionary<string, bool>();
        private Dictionary<string, bool> AvailabilityOfRailway = new Dictionary<string, bool>();
        private Dictionary<string, bool> AvailabilityOfAirway = new Dictionary<string, bool>();

        internal City(string name)
        {
            CityName = name;
        }
        internal void AddConnection(string ckey, double distance, bool highway, bool railway, bool airway)
        {
            CityKey.Add(ckey);
            Distance.Add(ckey, distance);
            AvailabilityOfHighway.Add(ckey, highway);
            AvailabilityOfRailway.Add(ckey, railway);
            AvailabilityOfAirway.Add(ckey, airway);

        }
    }
}
