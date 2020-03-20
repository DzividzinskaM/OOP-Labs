using System;
using System.Collections.Generic;
using System.Text;

namespace LibLab2
{
    internal class Route 
    {
        private string CityFrom;
        private string CityTo;
        private double Distance;
        private Way way = new Way();
        
        internal Route(string from, string to, double d, bool airway, bool highway, bool railway)
        {
            CityFrom = from;
            CityTo = to;
            Distance = d;
            way = new Way(airway, highway, railway);
        }

        internal Route()
        {

        }

        internal string GetCityFrom()
        {
            return CityFrom;
        }

        internal string GetCityTo()
        {
            return CityTo;
        }

        internal double GetDistance()
        {
            return Distance;
        }

        internal bool GetAirway()
        {
            return way.GetAirway();
        }

        internal bool GetRailway()
        {
            return way.GetRailway();
        }

        internal bool GetHighway()
        {
            return way.GetHighway();
        }
    }

}
