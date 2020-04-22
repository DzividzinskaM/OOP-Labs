using System;
using System.Collections.Generic;
using System.Text;

namespace LibLab3
{
    public class Weapon
    {
        public List<WeaponUnion> weaponsList { get; set; }

        public Weapon()
        {
            weaponsList = new List<WeaponUnion>();
        }

    }
}
