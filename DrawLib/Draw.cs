using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawLib
{
    public class Draw
    {
        public Image Buffer;

        public Draw(uint width, uint height)
        {
            Buffer = new Image(width, height);
        }

        public Draw(Image image)
        {
            Buffer = image;
        }

        private static class SpecialSymbolHandler
        {
            public static char Brightness(int level)
            {
                switch (level)
                {
                    case 0:     return ' ';
                    case 1:     return '░';
                    case 2:     return '▒';
                    case 3:     return '█';
                    default:    return '█';
                }
            }

            public static char Random()
            {
                string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
                return chars[new Random().Next(chars.Length)];
            }
        }

        private bool PrintSymbol(uint x, uint y)
        {
            var size = Buffer.GetSize();

            if (x > size.Item1 || y > size.Item2) return false;

            var currentFront = Console.ForegroundColor;
            var currentBack  = Console.BackgroundColor;

            var data     = (char)Buffer[x, y].Data;
            var special  = Buffer[x, y].SpecialChar;
            var front    = Buffer[x, y].FrontColor;
            var back     = Buffer[x, y].BackColor;

            Console.ForegroundColor = Symbol.ToConsoleColor(front);
            Console.BackgroundColor = Symbol.ToConsoleColor(back);

            if (special) // if uses special symbol
            {
                switch (data)
                {
                    case '0':
                        data = SpecialSymbolHandler.Brightness(0);
                        break;
                    case '1':
                        data = SpecialSymbolHandler.Brightness(1);
                        break;
                    case '2':
                        data = SpecialSymbolHandler.Brightness(2);
                        break;
                    case '3':
                        data = SpecialSymbolHandler.Brightness(3);
                        break;
                    case 'R':
                        data = SpecialSymbolHandler.Random();
                        break;
                    default:
                        data = '?';
                        break;
                }
            }

            Console.Write(data);

            Console.ForegroundColor = currentFront;
            Console.BackgroundColor = currentBack;

            return true;
        }

        public bool Print()
        {
            Console.Clear();

            var size = Buffer.GetSize();

            for (uint i = 0; i < size.Item1; i++)
            {
                for (uint j = 0; j < size.Item2; j++)
                {
                    if (PrintSymbol(i, j) == false)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;

                        return false;
                    }
                }
                Console.WriteLine();
            }

            return true;
        }
    }
}
