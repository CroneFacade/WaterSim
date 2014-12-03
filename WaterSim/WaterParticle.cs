using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaterSim
{
    class WaterParticle : Entity
    {
        public string PrintedName { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public bool CanMove { get; set; }

        public WaterParticle(int x, int y)
        {
            CanMove = true;
            PrintedName = "0";
            PositionX = x;
            PositionY = y;
        }
    }
}
