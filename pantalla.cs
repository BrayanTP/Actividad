using System;
using System.Collections.Generic;
using System.Text;

namespace Actividad
{
    class pantalla
    {
        public static void pantalla1(int y, int x)
        {
            
            Console.SetCursorPosition(1, 1); Console.Write("╔");
            Console.SetCursorPosition(119, 1); Console.Write("╗");
            Console.SetCursorPosition(1, 5); Console.Write("╠");
            Console.SetCursorPosition(119, 5); Console.Write("╣");
            Console.SetCursorPosition(1, 25); Console.Write("╚");
            Console.SetCursorPosition(119, 25); Console.Write("╝");

            for (x = 2; x <= 118; x++)
            {
                Console.SetCursorPosition(x, 1); Console.Write("═");
                Console.SetCursorPosition(x, 25); Console.Write("═");
                Console.SetCursorPosition(x , 5); Console.Write("═");
            }
            for (y = 2; y <= 4; y++)
            {
                Console.SetCursorPosition(1, y); Console.Write("║");
            }
            for (y = 6; y <= 24; y++)
            {
                Console.SetCursorPosition(1, y); Console.Write("║");
            }
            for (y = 2; y <= 4; y++)
            {
                Console.SetCursorPosition(1, y); Console.Write("║");
            }
            for (y = 2; y <= 4; y++)
            {
                Console.SetCursorPosition(119, y); Console.Write("║");

            }
            for (y = 6; y <= 24; y++)
            {
                Console.SetCursorPosition(119, y); Console.Write("║");

            }
        }

            
           


    }
}
