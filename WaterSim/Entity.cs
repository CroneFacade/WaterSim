using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaterSim
{
    public interface Entity
    {
        string PrintedName { get; set; }
        int PositionX { get; set; }
        int PositionY { get; set; }
    }
}
