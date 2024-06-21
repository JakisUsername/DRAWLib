using DrawLib;

internal class Program
{
    private static void Main(string[] args)
    {
        var image = new DrawLib.Image(20, 60);
        var draw = new DrawLib.Draw(image);

        string[] options = { "1. uruchom program 1", "2. uruchom program 2", "3. uruchom program 3", "4. zakoncz" };
        var controller = new Controller();

        // preprocessing 
        image.Fill(new Symbol(' ', false, Symbol.Color.White, Symbol.Color.Blue));

        var symbol = new Symbol('3', true);
        draw.Buffer.DrawRectangle(0, 0, 19, 59, symbol, true);
        //.

        while (true)
        {
            var selected = controller.GetSelectorPosition(4);

            draw.Buffer.DrawSelector(2, 2, options, selected);
            draw.Buffer.DrawString(41, 2, $"wybrana opcja: {selected}");
            draw.Print();

            var key = controller.ReadInput();
            if (key == "Enter")
            {
                switch (controller.GetSelectorPosition(4))
                {
                    case 0:
                        DrawLibTest.SubPrograms.ProgramSin();
                        break;
                    case 1:
                        DrawLibTest.SubPrograms.ProgramTopDown();
                        break;
                    case 2:
                        DrawLibTest.SubPrograms.ProgramRandom();
                        break;
                    case 3:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}