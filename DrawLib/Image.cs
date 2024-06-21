namespace DrawLib
{
    public struct Symbol
    {
        public byte Data;
        public bool SpecialChar;

        public enum Color
        {
            White, Black, Red, Green, Blue, Yellow, Magenta, Cyan, Random
        }

        public Color FrontColor;
        public Color BackColor;

        public Symbol(char data = ' ', bool specialChar = false, Color frontColor = Color.White, Color backColor = Color.Black)
        {
            Data = (byte)data;
            SpecialChar = specialChar;
            FrontColor = frontColor;
            BackColor = backColor;
        }

        internal static ConsoleColor ToConsoleColor(Color color)
        {
            switch (color)
            {
                case Color.White:   return ConsoleColor.White;
                case Color.Black:   return ConsoleColor.Black;
                case Color.Red:     return ConsoleColor.Red;
                case Color.Green:   return ConsoleColor.Green;
                case Color.Blue:    return ConsoleColor.Blue;
                case Color.Yellow:  return ConsoleColor.Yellow;
                case Color.Magenta: return ConsoleColor.Magenta;
                case Color.Cyan:    return ConsoleColor.Cyan;
                case Color.Random:  return ToConsoleColor((Color)(new Random().Next(7)));
                default:            return ConsoleColor.White;
            }
        }

        public override string ToString()
        {
            return "Symbol: " + Data + " | " + SpecialChar + " | " + FrontColor + " - " + BackColor;
        }
    }

    public class Image
    {
        internal Symbol[,] Buffer;

        public Image(uint width, uint height)
        {
            Buffer = new Symbol[width, height];
            Fill(new Symbol(' '));
        }

        public Symbol this[uint x, uint y]
        {
            get {
                return Buffer[x, y];
            }
            set {
                Buffer[x, y] = value;
            }
        }

        public (uint, uint) GetSize()
        {
            var x = (uint)Buffer.GetLength(0);
            var y = (uint)Buffer.GetLength(1);

            return (x, y);
        }

        public void WipeOut()
        {
            Buffer = new Symbol[Buffer.GetLength(0), Buffer.GetLength(1)];
            Fill(new Symbol(' '));
        }

        public void Fill(Symbol symbol)
        {
            var size = GetSize();

            for (uint i = 0; i < size.Item1; i++)
            {
                for (uint j = 0; j < size.Item2; j++)
                {
                    this[i, j] = symbol;
                }
            }
        }
    }
}
