using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaterSim
{
    class Simulation
    {
        public List<Borders> LineBorders { get; set; }

        public Simulation()
        {
            LineBorders = new List<Borders>();
            ListOfWater = new List<WaterParticle>();
        }


        internal void CreateMap()
        {
            GUI.PrintInstructions();
            int currentX = 0;
            int currentY = 0;
            bool keepGoing = true;
            while (keepGoing)
            {
                Entity empty = LookForBorder(currentX, currentY);
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
            Entity BorderToDelete = LookForBorder(currentX, currentY);
            GUI.CleanPosition(BorderToDelete, currentX, currentY);
            LineBorders.Remove((Borders)BorderToDelete);
        }

        private void CreateNewBorder(int currentX, int currentY)
        {
            var newBorder = new Borders(false);
            newBorder.PositionX = currentX;
            newBorder.PositionY = currentY;
            LineBorders.Add(newBorder);
            GUI.PrintEntity(newBorder);

        }

        private Entity LookForBorder(int currentX, int currentY)
        {
            foreach (var Border in LineBorders)
            {
                if ((Border.PositionX == currentX) && (Border.PositionY == currentY))
                {
                    return Border;
                }
            }
            foreach (var water in ListOfWater)
            {
                if (true)
                {
                    if ((water.PositionX == currentX) && (water.PositionY == currentY))
                    {
                        return water;
                    }
                }
            }
            return null;
        }

        internal void PlaySimulation()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            int currentX = 0;
            int currentY = 0;
            bool keepGoing = true;
            while (keepGoing)
            {
                Entity empty = LookForBorder(currentX, currentY);
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
                    case ConsoleKey.Enter:
                        BeginWaterSim(currentX, currentY);
                        break;
                    default:
                        break;
                }

            }
        }

        public List<WaterParticle> ListOfWater { get; set; }

        private void BeginWaterSim(int currentX, int currentY)
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                System.Threading.Thread.Sleep(25);
                var newWater = CreateNewWaterParticle(currentX, currentY);
                GUI.PrintEntity(newWater);
                MakeWaterFall();
            }
        }

        private void MakeWaterFall()
        {
            foreach (var waterParticle in ListOfWater)
            {
                bool blockedBelow = CheckIfBlockedBelow(waterParticle);

                if (blockedBelow)
                {
                    bool blockedRight = CheckIfBlockedSide((waterParticle.PositionX + 1), waterParticle.PositionY);
                    bool blockedLeft = CheckIfBlockedSide((waterParticle.PositionX - 1), waterParticle.PositionY);

                    if (!blockedLeft && blockedRight)
                    {
                        MoveParticle(waterParticle, waterParticle.PositionX - 1, waterParticle.PositionY);   
                    }
                    else if (blockedLeft && !blockedRight)
                    {
                        MoveParticle(waterParticle, waterParticle.PositionX + 1, waterParticle.PositionY);
                    }
                    else
                    {

                    }
                }
                else
                {
                    MoveParticle(waterParticle, waterParticle.PositionX, (waterParticle.PositionY + 1));
                }
            }

        }

        private bool CheckIfBlockedSide(int x, int y)
        {
            bool blocked = CheckForBlock(x, y);
            return blocked;
        }

        private void MoveParticle(WaterParticle waterParticle, int x, int y)
        {
            GUI.CleanPosition(null, waterParticle.PositionX, waterParticle.PositionY);
            waterParticle.PositionX = x;
            waterParticle.PositionY = y;
            GUI.PrintEntity(waterParticle);
        }

        private bool CheckIfBlockedBelow(WaterParticle waterParticle)
        {
            int xToCheck = waterParticle.PositionX;
            int yToCheck = (waterParticle.PositionY + 1);
            bool blocked = CheckForBlock(xToCheck, yToCheck);
            return blocked;
        }

        private bool CheckForBlock(int xToCheck, int yToCheck)
        {
            bool blocked = false;
            var foundBorder = LookForBorder(xToCheck, yToCheck);
            if (foundBorder == null)
            {
                foreach (var water in ListOfWater)
                {
                    if (((water.PositionX == xToCheck) && (water.PositionY == yToCheck)) && water.CanMove == false)
                    {
                        blocked = true;
                    }
                }
            }
            else
            {
                blocked = true;
            }
            return blocked;
        }

        private WaterParticle CreateNewWaterParticle(int currentX, int currentY)
        {
            var water = new WaterParticle(currentX, currentY);
            ListOfWater.Add(water);
            return water;
        }
    }
}
