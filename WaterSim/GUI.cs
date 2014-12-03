using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterSim
{
    public static class GUI
    {
        public static void CleanPosition(Borders empty, int currentX, int currentY)
        {
            if (empty == null)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(currentX, currentY);
                Console.Write("-");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(currentX, currentY);
                Console.Write(empty.PrintedName);
                Console.ResetColor();
            }
        }

        internal static void PrintBorder(Borders newBorder)
        {
            Console.SetCursorPosition(newBorder.PositionX, newBorder.PositionY);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(newBorder.PrintedName);
            Console.ResetColor();
        }
    }
}
