using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Kod_till_Spel.Menus;
public class Menu
{
    // Fixa in så att menyn "tabbar" ut texten och sedan lägger en pil där
    // \t tabbar ut texten men måste fixa så att jag kan använda tangenter istället för nummer
    public void StartMenu()
    {
        Load load1 = new Load();
        Colour colour = new Colour();
        Hero hero = new Hero();
        Status status = new Status();
        List<Hero> loadedHeroes = Save.LoadHeroes("Hero_save.json");

        string m1 = "\u001b[3mSpela\u001b[0m";
        string m2 = "\x1b[3mLadda Hjälte\x1b[0m";
        string m3 = "\x1b[3mAvsluta\x1b[0m";

        bool game = false;
        bool Load = false;

        string[] menuChoice1 =
        {
            m1,
            m2,
            m3
        };

        int menuSelecter1 = 0;
        bool menu = true;
        while (menu)
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(CenterText.CenterTexts2("\x1b[3m-<The Game>-\x1b[0m"));
            Console.WriteLine(CenterText.CenterTexts(@"          _____                    _____                    _____                   _______         "));
            Console.WriteLine(CenterText.CenterTexts(@"         /\    \                  /\    \                  /\    \                 /::\    \        "));
            Console.WriteLine(CenterText.CenterTexts(@"        /::\____\                /::\    \                /::\    \               /::::\    \       "));
            Console.WriteLine(CenterText.CenterTexts(@"       /:::/    /               /::::\    \              /::::\    \             /::::::\    \      "));
            Console.WriteLine(CenterText.CenterTexts(@"      /:::/    /               /::::::\    \            /::::::\    \           /::::::::\    \     "));
            Console.WriteLine(CenterText.CenterTexts(@"     /:::/    /               /:::/\:::\    \          /:::/\:::\    \         /:::/~~\:::\    \    "));
            Console.WriteLine(CenterText.CenterTexts(@"    /:::/____/               /:::/__\:::\    \        /:::/__\:::\    \       /:::/    \:::\    \   "));
            Console.WriteLine(CenterText.CenterTexts(@"   /::::\    \              /::::\   \:::\    \      /::::\   \:::\    \     /:::/    / \:::\    \  "));
            Console.WriteLine(CenterText.CenterTexts(@"  /::::::\    \   _____    /::::::\   \:::\    \    /::::::\   \:::\    \   /:::/____/   \:::\____\ "));
            Console.WriteLine(CenterText.CenterTexts(@" /:::/\:::\    \ /\    \  /:::/\:::\   \:::\    \  /:::/\:::\   \:::\____\ |:::|    |     |:::|    |"));
            Console.WriteLine(CenterText.CenterTexts(@"/:::/  \:::\    /::\____\/:::/__\:::\   \:::\____\/:::/  \:::\   \:::|    ||:::|____|     |:::|    |"));
            Console.WriteLine(CenterText.CenterTexts(@"\::/    \:::\  /:::/    /\:::\   \:::\   \::/    /\::/   |::::\  /:::|____| \:::\    \   /:::/    / "));
            Console.WriteLine(CenterText.CenterTexts(@" \/____/ \:::\/:::/    /  \:::\   \:::\   \/____/  \/____|:::::\/:::/    /   \:::\    \ /:::/    /  "));
            Console.WriteLine(CenterText.CenterTexts(@"          \::::::/    /    \:::\   \:::\    \            |:::::::::/    /     \:::\    /:::/    /   "));
            Console.WriteLine(CenterText.CenterTexts(@"           \::::/    /      \:::\   \:::\____\           |::|\::::/    /       \:::\__/:::/    /    "));
            Console.WriteLine(CenterText.CenterTexts(@"           /:::/    /        \:::\   \::/    /           |::| \::/____/         \::::::::/    /     "));
            Console.WriteLine(CenterText.CenterTexts(@"          /:::/    /          \:::\   \/____/            |::|  ~|                \::::::/    /      "));
            Console.WriteLine(CenterText.CenterTexts(@"         /:::/    /            \:::\    \                |::|   |                 \::::/    /       "));
            Console.WriteLine(CenterText.CenterTexts(@"        /:::/    /              \:::\____\               \::|   |                  \::/____/        "));
            Console.WriteLine(CenterText.CenterTexts(@"        \::/    /                \::/    /                \:|   |                   ~~              "));
            Console.WriteLine(CenterText.CenterTexts(@"         \/____/                  \/____/                  \|___|                                   "));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < menuChoice1.Length; i++)
            {
                if (i == menuSelecter1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(CenterText.CenterMenu2($"{menuChoice1[i]}\t <---"));
                    Console.ResetColor();
                    Console.CursorVisible = false;
                }
                else
                    Console.WriteLine(CenterText.CenterTextss(menuChoice1[i]));
            }

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.DownArrow && menuSelecter1 < menuChoice1.Length - 1)
            {
                menuSelecter1++;
            }
            else if (key == ConsoleKey.UpArrow && menuSelecter1 >= 1)
            {
                menuSelecter1--;
            }
            else if (key == ConsoleKey.Enter)
            {
                switch (menuSelecter1)
                {
                    case 0:
                        game = true;
                        menu = false;
                        break;

                    case 1:
                        if (loadedHeroes != null && loadedHeroes.Count > 0)
                        {
                            Load = true;
                            menu = false;
                        }
                        else
                        {
                            Console.WriteLine(CenterText.CenterTexts("Inga hjältar att ladda."));
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        Console.WriteLine(CenterText.CenterTexts("Bye bye"));
                        menu = false;
                        break;
                }
            }
        }

        if (Load)
        {
            bool load = true;
            while (load)
            {
                if (loadedHeroes != null && loadedHeroes.Count > 0)
                {
                    Console.WriteLine(CenterText.CenterTexts("Välj vilken hjälte du vill ladda:"));
                    for (int i = 0; i < loadedHeroes.Count; i++)
                    {
                        Console.WriteLine(CenterText.CenterTexts($"{i + 1}. {loadedHeroes[i].name}"));
                    }

                    bool validInput = int.TryParse(Console.ReadLine(), out int selectedHeroIndex);
                    if (validInput && selectedHeroIndex > 0 && selectedHeroIndex <= loadedHeroes.Count)
                    {
                        GameState.CurrentHero = loadedHeroes[selectedHeroIndex - 1];
                        Console.WriteLine(CenterText.CenterTexts($"Hjälten {hero.name} har laddats."));
                    }
                    else
                    {
                        Console.WriteLine(CenterText.CenterTexts("Ogiltigt val."));
                    }
                }
                else
                    Console.WriteLine(CenterText.CenterTexts("Inga hjältar att ladda."));
                Console.ReadKey();
                break;
            }
        }
        else if (game)
        {
            do
            {
                Console.Write("Ange ett namn till din Hjälte: ");
                GameState.CurrentHero = new Hero { name = Console.ReadLine() };

            } while (GameState.CurrentHero.name == "");
        }

        if (game || Load)
        {
            bool Running = true;
            do
            {
                GamePlay.gamePlay();
            } while (Running);
        }
    }
}


