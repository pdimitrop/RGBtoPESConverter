using System.Diagnostics;

class PESRGBConverter
{
    private static int R { get; set; }
    private static int G { get; set; }
    private static int B { get; set; }
    private static int Rpes { get; set; }
    private static int Gpes { get; set; }
    private static int Bpes { get; set; }

    static void Main(string[] args)
    {
        R = ReadRGBValue("Please enter the Red (R) Value:");
        Rpes = Converter(R);

        G = ReadRGBValue("Please enter the Green (G) Value:");
        Gpes = Converter(G);

        B = ReadRGBValue("Please enter the Blue (B) Value:");
        Bpes = Converter(B);

        Console.WriteLine($"R: {Rpes} - G: {Gpes} - B: {Bpes}");
        Console.WriteLine("Press \'R\' to restart.");

        var info = Console.ReadKey();
        if (info.Key == ConsoleKey.R)
        {
            var fileName = Process.GetCurrentProcess().MainModule!.FileName;
            Process.Start(fileName);
        }

        Console.Clear();
    }

    private static int ReadRGBValue(string prompt)
    {
        int value;
        Console.WriteLine(prompt);
        while (!int.TryParse(Console.ReadLine(), out value) || value < 0 || value > 255)
        {
            Console.WriteLine("Invalid input. Please enter a whole number between 0 and 255:");
        }
        return value;
    }

    private static int Converter(int c)
    {
        return (int)Math.Round(c * 63.0 / 255.0, MidpointRounding.AwayFromZero);
    }
}