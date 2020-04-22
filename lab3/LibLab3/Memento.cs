using System;
using System.Collections.Generic;
using System.Text;

namespace LibLab3
{
    public class Memento
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public float Health { get; set; }

        public WeaponUnion Weapon { get; set; }

        public Memento(int x, int y, float h, WeaponUnion w)
        {
            PositionX = x;
            PositionY = y;
            Health = h;
            Weapon = w;
        }

    }
}
