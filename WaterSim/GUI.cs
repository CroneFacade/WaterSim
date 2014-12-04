using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterSim
{
    public static class GUI
    {
        public static void CleanPosition(Entity empty, int currentX, int currentY)
        {
            if (empty == null)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(currentX, currentY);
                Console.Write(" ");
                //Console.ResetColor();
                Console.SetCursorPosition(75, 20);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(currentX, currentY);
                Console.Write(empty.PrintedName);
                //Console.ResetColor();
                Console.SetCursorPosition(75, 20);
            }
        }

        internal static void PrintEntity(Entity newEntity)
        {
            Console.SetCursorPosition(newEntity.PositionX, newEntity.PositionY);
            //Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(newEntity.PrintedName);
            //Console.ResetColor();
            Console.SetCursorPosition(75, 20);
        }

        internal static void CurrentCursorPosition(int currentX, int currentY)
        {
            Console.SetCursorPosition(currentX, currentY);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(" ");
            //Console.ResetColor();
            Console.SetCursorPosition(75, 20);
        }


        internal static void PrintInstructions()
        {
            Console.WriteLine("Welcome to WaterSim!");
            Console.WriteLine("These are your controls!");
            Console.WriteLine("Use Arrow keys to move your cursor which will be displayed as a red box");
            Console.WriteLine("Press B to build a border on your current location");
            Console.WriteLine("Press D to delete a border you are hovering over");
            Console.WriteLine("Press Q when you are done building your borders");
            Console.WriteLine("When you have hit Q, you have to select the location where you want the water to originate from.");
            Console.WriteLine("You press Enter to start the water simulation");
            Console.WriteLine("Press Any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
