using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawLib
{
    public static class Form
    {
        public static void DrawRectangle(this Image image, uint x, uint y, uint width, uint height, Symbol symbol, bool outlineOnly = false)
        {
            var size = image.GetSize();

            for (uint i = y; i <= height; i++ )
            {
                for (uint j = x; j <= width; j++)
                {
                    if (outlineOnly)
                    {
                        bool bx = j == 0 || j == width;
                        bool by = i == 0 || i == height;

                        if (bx || by) image[j, i] = symbol;
                    }
                    else
                    {
                        image[j, i] = symbol;
                    }
                }
            }
        }

        public static void DrawString(this Image image, uint x, uint y, string content, bool flip = false, Symbol.Color FrontColor = Symbol.Color.White, Symbol.Color BackColor = Symbol.Color.Black)
        {
            var split = content.Split('\n');

            for (uint i = 0; i < split.Length; i++)
            {
                for (uint j = 0; j < split[i].Length; j++)
                {
                    if (!flip) 
                        image[y + i, x + j] = new Symbol(split[(int)i][(int)j], false, FrontColor, BackColor);
                    else
                        image[y + j, x + i] = new Symbol(split[(int)i][(int)j], false, FrontColor, BackColor);

                }
            }
        }

        public static void DrawSelector(this Image image, uint x, uint y, string[] options, byte selected = 0, Symbol.Color FrontColor = Symbol.Color.White, Symbol.Color BackColor = Symbol.Color.Black)
        {
            for (uint i = 0; i < options.Length; i++)
            {
                if (selected != i)
                    image.DrawString(x, y + i, options[i], false, FrontColor, BackColor);
                else
                    image.DrawString(x, y + i, options[i], false, BackColor, FrontColor);
            }
        }
    }
}
