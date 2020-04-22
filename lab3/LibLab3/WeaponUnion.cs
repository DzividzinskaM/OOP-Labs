using System;
using System.Collections.Generic;
using System.Text;

namespace LibLab3
{
    public struct WeaponUnion
    {
        public string Name { get; }
        public float HealthDownPosition { get; }
        public int Source { get; set; }

        public WeaponUnion(string name, float healthDownPos, int source)
        {
            Name = name;
            HealthDownPosition = healthDownPos;
            Source = source;
        }
    }
}
