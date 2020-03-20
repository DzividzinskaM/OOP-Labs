using System;
using System.Collections.Generic;
using System.Text;

namespace LibLab2
{
    internal class RouteCreator
    {
        private List<Route> Routes = new List<Route>();
        internal RouteCreator()
        {
            CreateRandomRouts();
        }

        private void CreateRandomRouts()
        {
            Route route = new Route("Kyiv", "Chernivtsi", 507, true, true, true);
            Routes.Add(route);
            CreateReturnRoute(route);
            route = new Route("Kyiv", "New York", 7527, true, false, false);
            Routes.Add(route);
            CreateReturnRoute(route);
            route = new Route("Kyiv", "Fastiv", 75, false, true, true);
            Routes.Add(route);
            CreateReturnRoute(route);


        }

        private void CreateReturnRoute(Route route)
        {
            route = new Route(route.GetCityTo(), route.GetCityFrom(), route.GetDistance(), route.GetAirway(),
                route.GetHighway(), route.GetRailway());
            Routes.Add(route);
        }

        internal List<Route> GetRoutesMap()
        {
            return Routes;
        }

        internal Route GetRoute(string from, string to)
        {
            Route route = new Route();
            foreach(var value in Routes)
            {
                if(value.GetCityFrom() == from && value.GetCityTo() == to)
                {
                    route = value;
                }
            }
            return route;
        }
    }
}
