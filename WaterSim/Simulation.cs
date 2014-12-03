using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaterSim
{
    class Simulation
    {
        List<Borders> LineBorders;

        public Simulation()
        {
            LineBorders = new List<Borders>();
        }


        internal void CreateMap()
        {
            int currentX = 0;
            int currentY = 0;
            bool keepGoing = true;
            while (keepGoing)
            {
                Borders empty = LookForBorder(currentX, currentY);
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                GUI.CleanPosition(empty, currentX, currentY);

                switch (pressedKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        currentX--;
                        break;
                    case ConsoleKey.RightArrow:
                        currentX++;
                        break;
                    case ConsoleKey.UpArrow:
                        currentY--;
                        break;
                    case ConsoleKey.DownArrow:
                        currentY++;
                        break;
                    case ConsoleKey.B:
                        var newBorder = new Borders(false);
                        newBorder.PositionX = currentX;
                        newBorder.PositionY = currentY;
                        LineBorders.Add(newBorder);
                        GUI.PrintBorder(newBorder);
                        break;
                    case ConsoleKey.D:
                        Borders BorderToDelete = LookForBorder(currentX, currentY);
                        GUI.CleanPosition(BorderToDelete, currentX, currentY);
                        LineBorders.Remove(BorderToDelete);
                        break;
                    default:
                        break;
                }
                
            }
        }

        private Borders LookForBorder(int currentX, int currentY)
        {
            foreach (var Border in LineBorders)
            {
                if ((Border.PositionX == currentX) && (Border.PositionY == currentY))
                {
                    return Border;
                }
            }
            return null;
        }

        internal void PlaySimulation()
        {
            throw new NotImplementedException();
        }
    }
}
