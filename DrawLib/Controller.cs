using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawLib
{
    public class Controller
    {
        uint position = 0;

        public byte GetSelectorPosition(uint selectorSize)
        {
            return (byte)(position % selectorSize);
        }

        public string ReadInput()
        {
            var key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.DownArrow:
                    position++;
                    break;
                case ConsoleKey.UpArrow:
                    position--;
                    break;
            }

            return key.ToString();
        }
    }
}
