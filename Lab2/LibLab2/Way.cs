using System;
using System.Collections.Generic;
using System.Text;

namespace LibLab2
{
    internal class Way 
    {
        private bool Airway;
        private bool Highway;
        private bool Railway;

        internal Way()
        {

        }

        internal Way(bool a, bool h, bool r)
        {
            Airway = a;
            Highway = h;
            Railway = r;
        }

        internal bool GetAirway()
        {
            return Airway;
        }

        internal bool GetHighway()
        {
            return Highway;
        }

        internal bool GetRailway()
        {
            return Railway;
        }
    }
}
