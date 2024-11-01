using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kod_till_Spel;
internal class Skapare
{
    public static void Namn()
    {
        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;

        string text = "Game made of #Christofer Hägg";
        int textLength = text.Length;

        int xPosition = consoleWidth - textLength; // x-position
        int yPosition = consoleHeight - 1; // y-position

        Console.SetCursorPosition(xPosition, yPosition);
        Console.WriteLine(text);
    }
}
