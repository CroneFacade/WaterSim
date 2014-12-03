using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaterSim
{
    class Borders
    {
        public string PrintedName { get; set; }
        public bool Breakable { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Borders(bool breakable)
        {
            PrintedName = "#";
            this.Breakable = breakable;
        }
    }
}
