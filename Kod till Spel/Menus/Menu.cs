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
            Attack attack = new Attack();
            Healing healing = new Healing();
            Save save = new Save();
            Dungeons dungeon = new Dungeons(hero);

            string menu1 = "Kolla Status på din hjälte";
            string menu2 = CenterText.CenterTexts("Roama runt och Attackera mobs");
            string menu3 = CenterText.CenterTexts("Utrustade föremål");
            string menu4 = CenterText.CenterTexts("Kolla hittade föremål");
            string menu5 = CenterText.CenterTexts("Öppna Shopen");
            string menu6 = CenterText.CenterTexts("Meditera (Heala din hjälte)");
            string menu7 = CenterText.CenterTexts("Dungeons");
            string menu8 = CenterText.CenterTexts("Spara din hjälte");
            string menu9 = CenterText.CenterTexts("Ladda en hjälte");
            string menu10 = CenterText.CenterTexts("Stänga Programmet");


            string[] menuChoice = {
            "Kolla Status på din hjälte",
            "Roama runt och Attackera mobs",
            "Titlar",
            "Utrustade föremål",
            "Kolla hittade föremål",
            "Öppna Shopen",
            "Meditera (Heala din hjälte)",
            "Dungeons",
            "Spara din hjälte",
            "Ladda en hjälte",
            "Stänga Programmet"
        };
            int menuSelecter = 0;

            bool spel = true;
            while (spel)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(CenterText.CenterTexts($"A game created by #Christofer Hägg"));
                Console.WriteLine();
                Console.WriteLine();

                for (int i = 0; i < menuChoice.Length; i++)
                {
                    if (i == menuSelecter)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(CenterText.CenterMenu($"{menuChoice[i]}\t <---"));
                        Console.ResetColor();
                        Console.CursorVisible = false;
                    }
                    else
                        Console.WriteLine(CenterText.CenterTexts(menuChoice[i]));
                }

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.DownArrow && menuSelecter < menuChoice.Length - 1)
                {
                    menuSelecter++;
                }
                else if (key == ConsoleKey.UpArrow && menuSelecter >= 1)
                {
                    menuSelecter--;
                }
                else if (key == ConsoleKey.Enter)
                {
                    switch (menuSelecter)
                    {
                        case 0:
                            status.StatusMenu();
                            break;

                        case 1:
                            Console.Clear();
                            attack._Attack();
                            break;
                        case 2:
                            Console.Clear();
                            hero.TitleManagement();
                            break;
                        case 3:
                            Console.Clear();
                            //Console.WriteLine("Finns inget här just nu, men kommer inom snart!");
                            GameState.CurrentHero.ShowEquippedItems();
                            Console.ReadKey();
                            break;

                        case 4:
                            Console.Clear();
                            GameState.CurrentHero.ManageInventory();
                            break;

                        case 5:
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine(CenterText.CenterTexts("Det finns inget här för tillfället. Mer kommer inom kort!"));
                            Console.ReadKey();
                            break;

                        case 6:
                            Console.Clear();
                            healing._Healing();
                            break;

                        case 7:
                            Console.Clear();
                            dungeon.EnterDungeon(GameState.CurrentHero);
                            break;

                        case 8:
                            Console.Clear();
                            Save.SaveHeroes(GameState.CurrentHero, "Hero_save.json");
                            hero.Stats();
                            Console.ReadKey();
                            break;

                        case 9:
                            Console.Clear();
                            Console.WriteLine(CenterText.CenterTexts("Har du sparat din hjälte innan?"));
                            string svar = Console.ReadLine().ToLower();
                            if (svar == "ja" || svar == "yes" || svar == "j" || svar == "y" || svar == "ye")
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
                                break;
                            }
                            else
                                break;

                        case 10:
                            Console.Clear();
                            Console.WriteLine(CenterText.CenterTexts("Tack för att du använder detta programmet, nu avslutas programmet"));
                            spel = false;
                            break;
                    }
                }
            }
        }
    }
}


