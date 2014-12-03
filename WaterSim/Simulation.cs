using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaterSim
{
    class Simulation
    {
        public List<Borders> LineBorders;

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
                        GUI.CurrentCursorPosition(currentX, currentY);
                        break;
                    case ConsoleKey.RightArrow:
                        currentX++;
                        GUI.CurrentCursorPosition(currentX, currentY);
                        break;
                    case ConsoleKey.UpArrow:
                        currentY--;
                        GUI.CurrentCursorPosition(currentX, currentY);
                        break;
                    case ConsoleKey.DownArrow:
                        currentY++;
                        GUI.CurrentCursorPosition(currentX, currentY);
                        break;
                    case ConsoleKey.B:
                        var findBorder = LookForBorder(currentX, currentY);

                        if (findBorder == null)
                        {
                            CreateNewBorder(currentX, currentY);
                        }
                        break;
                    case ConsoleKey.D:
                        DeleteBorder(currentX, currentY);
                        break;
                    case ConsoleKey.Q:
                        keepGoing = false;
                        break;
                    default:
                        break;
                }
                
            }
        }

        private void DeleteBorder(int currentX, int currentY)
        {
            Borders BorderToDelete = LookForBorder(currentX, currentY);
            GUI.CleanPosition(BorderToDelete, currentX, currentY);
            LineBorders.Remove(BorderToDelete);
        }

        private void CreateNewBorder(int currentX, int currentY)
        {
            var newBorder = new Borders(false);
            newBorder.PositionX = currentX;
            newBorder.PositionY = currentY;
            LineBorders.Add(newBorder);
            GUI.PrintBorder(newBorder);

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
