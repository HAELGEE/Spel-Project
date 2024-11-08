using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kod_till_Spel.Menus;
internal class MenuChoice
{
    // Skickar in menu options, längden på array av menu options, texten som skall stå INNAN loopen.
    // Hur skickar jag in så det blir rätt switch?
    public static void MenuChoices(string[] menuChoice, int lengthOfArray, string beforeText)
    {
        int menuSelecter = 0;

        bool spel = true;
        while (spel)
        {
            Console.Clear();
            
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(CenterText.CenterTexts(beforeText));
            Console.WriteLine();

            for (int i = 0; i < lengthOfArray; i++)
            {
                if (i == menuSelecter)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(CenterText.CenterTexts($"{menuChoice[i]}"));
                    Console.ResetColor();
                    Console.CursorVisible = false;
                }
                else
                    Console.WriteLine(CenterText.CenterTextsss(menuChoice[i]));
            }

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.DownArrow && menuSelecter < lengthOfArray - 1)
            {
                menuSelecter++;
            }
            else if (key == ConsoleKey.UpArrow && menuSelecter >= 1)
            {
                menuSelecter--;
            }
            else if (key == ConsoleKey.Enter)
            {
                if (lengthOfArray == 1)
                {
                    switch (menuSelecter)
                    {
                        case 0:

                            spel = false;
                            break;

                        default:
                            Console.WriteLine(CenterText.CenterTexts("Ogiltigt val, försök igen"));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                if (lengthOfArray == 2)
                {
                    switch (menuSelecter)
                    {
                        case 0:
                            spel = false;
                            break;

                        case 1:
                            Console.Clear();
                            spel = false;
                            break;

                        default:
                            Console.WriteLine(CenterText.CenterTexts("Ogiltigt val, försök igen"));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                if (lengthOfArray == 3)
                {
                    switch (menuSelecter)
                    {
                        case 0:
                            spel = false;
                            break;

                        case 1:
                            Console.Clear();
                            spel = false;
                            break;
                        case 2:
                            Console.Clear();
                            spel = false;
                            break;

                        default:
                            Console.WriteLine(CenterText.CenterTexts("Ogiltigt val, försök igen"));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                if (lengthOfArray == 4)
                {
                    switch (menuSelecter)
                    {
                        case 0:
                            spel = false;
                            break;

                        case 1:
                            Console.Clear();
                            spel = false;
                            break;
                        case 2:
                            Console.Clear();
                            Console.ReadKey();
                            spel = false;
                            break;

                        case 3:
                            Console.Clear();
                            spel = false;
                            break;

                        default:
                            Console.WriteLine(CenterText.CenterTexts("Ogiltigt val, försök igen"));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                if (lengthOfArray == 5)
                {
                    switch (menuSelecter)
                    {
                        case 0:
                            spel = false;
                            break;

                        case 1:
                            Console.Clear();
                            spel = false;
                            break;
                        case 2:
                            Console.Clear();
                            Console.ReadKey();
                            spel = false;
                            break;

                        case 3:
                            Console.Clear();
                            spel = false;
                            break;

                        case 4:
                            Console.Clear();                            
                            spel = false;
                            break;

                        default:
                            Console.WriteLine(CenterText.CenterTexts("Ogiltigt val, försök igen"));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                if (lengthOfArray == 6)
                {
                    switch (menuSelecter)
                    {
                        case 0:
                            spel = false;
                            break;

                        case 1:
                            Console.Clear();
                            spel = false;
                            break;
                        case 2:
                            Console.Clear();
                            Console.ReadKey();
                            spel = false;
                            break;

                        case 3:
                            Console.Clear();
                            spel = false;
                            break;

                        case 4:
                            Console.Clear();
                            Console.ReadKey();
                            spel = false;
                            break;

                        case 5:
                            Console.Clear();
                            spel = false;
                            break;

                        default:
                            Console.WriteLine(CenterText.CenterTexts("Ogiltigt val, försök igen"));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                if (lengthOfArray == 7)
                {
                    switch (menuSelecter)
                    {
                        case 0:
                            spel = false;
                            break;

                        case 1:
                            Console.Clear();
                            spel = false;
                            break;
                        case 2:
                            Console.Clear();
                            Console.ReadKey();
                            spel = false;
                            break;

                        case 3:
                            Console.Clear();
                            spel = false;
                            break;

                        case 4:
                            Console.Clear();
                            Console.ReadKey();
                            spel = false;
                            break;

                        case 5:
                            Console.Clear();
                            spel = false;
                            break;

                        case 6:
                            Console.Clear();
                            spel = false;
                            break;

                        case 7:
                            Console.Clear();
                            spel = false;
                            break;

                        default:
                            Console.WriteLine(CenterText.CenterTexts("Ogiltigt val, försök igen"));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                if (lengthOfArray == 8)
                {
                    switch (menuSelecter)
                    {
                        case 0:
                            spel = false;
                            break;

                        case 1:
                            Console.Clear();
                            spel = false;
                            break;
                        case 2:
                            Console.Clear();
                            Console.ReadKey();
                            spel = false;
                            break;

                        case 3:
                            Console.Clear();
                            spel = false;
                            break;

                        case 4:
                            Console.Clear();
                            Console.ReadKey();
                            spel = false;
                            break;

                        case 5:
                            Console.Clear();
                            spel = false;
                            break;

                        case 6:
                            Console.Clear();
                            spel = false;
                            break;

                        case 7:
                            Console.Clear();
                            Console.ReadKey();
                            spel = false;
                            break;

                        case 8:
                            Console.Clear();
                            spel = false;
                            break;

                        default:
                            Console.WriteLine(CenterText.CenterTexts("Ogiltigt val, försök igen"));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                if (lengthOfArray == 9)
                {
                    switch (menuSelecter)
                    {
                        case 0:
                            spel = false;
                            break;

                        case 1:
                            Console.Clear();
                            spel = false;
                            break;
                        case 2:
                            Console.Clear();
                            Console.ReadKey();
                            spel = false;
                            break;

                        case 3:
                            Console.Clear();
                            spel = false;
                            break;

                        case 4:
                            Console.Clear();
                            Console.ReadKey();
                            spel = false;
                            break;

                        case 5:
                            Console.Clear();
                            spel = false;
                            break;

                        case 6:
                            Console.Clear();
                            spel = false;
                            break;

                        case 7:
                            Console.Clear();
                            Console.ReadKey();
                            spel = false;
                            break;

                        case 8:
                            Console.Clear();
                            spel = false;
                            break;

                        case 9:
                            Console.Clear();
                            spel = false;
                            break;

                        default:
                            Console.WriteLine(CenterText.CenterTexts("Ogiltigt val, försök igen"));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }
        }
    }
}
