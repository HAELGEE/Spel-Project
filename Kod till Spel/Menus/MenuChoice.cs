using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kod_till_Spel.Menus;
internal class MenuChoice
{
    //// Skickar in menu options, längden på array av menu options, texten som skall stå INNAN loopen.
    //// Hur skickar jag in så det blir rätt switch?
    //public void MenuChoices(string menuChoice, int lengthOfArray, string beforeText)
    //{        
    //    int menuSelecter = 0;

    //    bool spel = true;
    //    while (spel)
    //    {
    //        Console.Clear();
    //        // Här skickas "För text" in(sånt som inte skall vara med i loopen)
    //        //Console.WriteLine($"=== TEXT SPEL ===          A game created by #Christofer Hägg");
    //        Console.WriteLine(beforeText);

    //        for (int i = 0; i < lengthOfArray; i++)
    //        {
    //            if (i == menuSelecter)
    //            {
    //                Console.ForegroundColor = ConsoleColor.Green;
    //                Console.WriteLine($"---> \t {(menuChoice[i])}");
    //                Console.ResetColor();
    //                Console.CursorVisible = false;
    //            }
    //            else
    //                Console.WriteLine(menuChoice[i]);
    //        }

    //        var key = Console.ReadKey(true).Key;

    //        if (key == ConsoleKey.DownArrow && menuSelecter < lengthOfArray - 1)
    //        {
    //            menuSelecter++;
    //        }
    //        else if (key == ConsoleKey.UpArrow && menuSelecter >= 1)
    //        {
    //            menuSelecter--;
    //        }
    //        else if (key == ConsoleKey.Enter)
    //        {
    //            switch (menuSelecter)
    //            {
    //                case 0:
    //                    status.StatusMenu();
    //                    break;

    //                case 1:
    //                    Console.Clear();
    //                    attack._Attack(hero);
    //                    break;
    //                case 2:
    //                    Console.Clear();
    //                    //Console.WriteLine("Finns inget här just nu, men kommer inom snart!");
    //                    hero.ShowEquippedItems();
    //                    Console.ReadKey();
    //                    break;

    //                case 3:
    //                    Console.Clear();
    //                    hero.ManageInventory();
    //                    break;

    //                case 4:
    //                    Console.Clear();
    //                    Console.WriteLine("Det finns inget här för tillfället. Mer kommer inom kort!");
    //                    Console.ReadKey();
    //                    break;

    //                case 5:
    //                    Console.Clear();
    //                    healing._Healing(hero);
    //                    break;

    //                case 6:
    //                    Console.Clear();
    //                    dungeon.EnterDungeon();
    //                    break;

    //                case 7:
    //                    Console.Clear();
    //                    Save.SaveHeroes(hero, "Hero_save.json");
    //                    hero.Stats();
    //                    Console.ReadKey();
    //                    break;

    //                case 8:
    //                    Console.Clear();
    //                    Console.WriteLine("Kommmer ngt inom kort");
    //                    break;

    //                case 9:
    //                    Console.Clear();
    //                    Console.WriteLine("Tack för att du använder detta programmet, nu avslutas programmet");
    //                    spel = false;
    //                    break;

    //                default:
    //                    Console.WriteLine("Ogiltigt val, försök igen");
    //                    Console.ReadKey();
    //                    Console.Clear();
    //                    break;
    //            }
    //        }
    //    }
    //}
}
