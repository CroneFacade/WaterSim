using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaterSim
{
    class Simulation
    {
        List<Borders> LineBorders;

        public enum MoveCursor
        {
            Up,
            Down,
            Left,
            Right
        }

        public Simulation()
        {
            LineBorders = new List<Borders>();
        }


        internal void CreateMap()
        {
            throw new NotImplementedException();
        }

        internal void PlaySimulation()
        {
            throw new NotImplementedException();
        }
    }
}
