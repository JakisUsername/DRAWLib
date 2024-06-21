using DrawLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DrawLibTest
{
    internal static class SubPrograms
    {
        public static void ProgramSin()
        {
            var image = new DrawLib.Image(20, 60);
            var draw = new DrawLib.Draw(image);

            var controller = new Controller();

            const int ycenter = 10;
            var sinsymbol = new DrawLib.Symbol('3', true, Symbol.Color.Cyan);
            int sinpos = 0;

            var sqsymbol = new Symbol('3', true);

            while (true)
            {
                draw.Buffer.WipeOut();

                for (uint i = 0; i < 60; i++)
                {
                    double pos = (double)(sinpos + (int)i)/4;
                    var offset = (int)(Math.Round(Math.Sin(pos)*3));
                    draw.Buffer[(uint)(ycenter + offset), i] = sinsymbol;
                }
                
                draw.Buffer.DrawRectangle(0, 0, 19, 59, sqsymbol, true);

                draw.Buffer.DrawString(2, 2, "nacisnij 'Q' by wyjsc,\ninny dowolny by przesunac sin");
                draw.Print();

                var key = controller.ReadInput();
                if (key == "Q") return;

                sinpos++;
            }
        }

        public static void ProgramTopDown()
        {
            var image = new DrawLib.Image(20, 60);
            var draw = new DrawLib.Draw(image);

            var controller = new Controller();

            var pointpos = new Vector2(10, 10);
            var pointsymbol = new Symbol('3', true, Symbol.Color.Magenta);

            var sqsymbol = new Symbol('3', true);

            while (true)
            {
                draw.Buffer.WipeOut();

                draw.Buffer.DrawString(2, 2, "nacisnij 'Q' by wyjsc,\nstrzalki by sie poruszac");

                draw.Buffer[(uint)pointpos[1], (uint)pointpos[0]] = pointsymbol;

                draw.Buffer.DrawRectangle(0, 0, 19, 59, sqsymbol, true);

                draw.Print();

                var key = controller.ReadInput();
                if (key == "Q") return;

                switch (key)
                {
                    case "RightArrow":
                        pointpos[0]++;
                        break;
                    case "LeftArrow":
                        pointpos[0]--;
                        break;
                    case "DownArrow":
                        pointpos[1]++;
                        break;
                    case "UpArrow":
                        pointpos[1]--;
                        break;
                }

                pointpos[0] = Math.Clamp(pointpos[0], 1, 58);
                pointpos[1] = Math.Clamp(pointpos[1], 1, 18);
            }
        }

        public static void ProgramRandom()
        {
            var image = new DrawLib.Image(20, 60);
            var draw = new DrawLib.Draw(image);

            var controller = new Controller();

            var bgsymbol = new DrawLib.Symbol('R', true, Symbol.Color.Random, Symbol.Color.Random);

            var sqsymbol = new Symbol('3', true);

            while (true)
            {
                draw.Buffer.WipeOut();

                draw.Buffer.DrawRectangle(1, 1, 18, 58, bgsymbol, false);
                draw.Buffer.DrawRectangle(0, 0, 19, 59, sqsymbol, true);

                draw.Buffer.DrawString(2, 2, "nacisnij 'Q' by wyjsc,\ninny dowolny by losować kolory");
                draw.Print();

                var key = controller.ReadInput();
                if (key == "Q") return;
            }
        }

    }
}
