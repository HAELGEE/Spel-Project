using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        bool load = true;
        while (load)
        {
            Console.Clear();
            Console.WriteLine("Vill du ladda en hjälte? J/N");
            string choice = Console.ReadLine();
            if (choice.ToUpper() == "J")
            {
                List<Hero> loadedHeroes = Save.LoadHeroes("Hero_save.json");
                if (loadedHeroes != null && loadedHeroes.Count > 0)
                {
                    Console.WriteLine("Välj vilken hjälte du vill ladda:");
                    for (int i = 0; i < loadedHeroes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {loadedHeroes[i].name}");
                    }

                    bool validInput = int.TryParse(Console.ReadLine(), out int selectedHeroIndex);
                    if (validInput && selectedHeroIndex > 0 && selectedHeroIndex <= loadedHeroes.Count)
                    {
                        GameState.CurrentHero = loadedHeroes[selectedHeroIndex - 1];
                        Console.WriteLine($"Hjälten {hero.name} har laddats.");
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt val.");
                    }
                }
                else
                {
                    Console.WriteLine("Inga hjältar att ladda.");
                    do
                    {
                        Console.Write("\nAnge ett namn till din Hjälte: ");
                        GameState.CurrentHero = new Hero { name = Console.ReadLine() };
                    } while (GameState.CurrentHero.name == null);
                }
                Console.ReadKey();
                break;
            }
            else if (choice.ToUpper() == "N")
            {
                Console.Write("Ange ett namn till din Hjälte: ");
                GameState.CurrentHero = new Hero { name = Console.ReadLine() };
                break;
            }
            else
            {
                Console.WriteLine("Ogiltig inmatning, försök igen.");
            }
        }
        Attack attack = new Attack();
        Healing healing = new Healing();
        Save save = new Save();
        Dungeons dungeon = new Dungeons(hero);

        string[] menuChoice = {
            "Kolla Status på din hjälte",
            "Roama runt och Attackera mobs",
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
            Console.WriteLine($"=== TEXT SPEL ===          A game created by #Christofer Hägg");

            for (int i = 0; i < menuChoice.Length; i++)
            {
                if (i == menuSelecter)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"---> \t {menuChoice[i]}");
                    Console.ResetColor();
                    Console.CursorVisible = false;
                }
                else
                    Console.WriteLine(menuChoice[i]);
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
                        //Console.WriteLine("Finns inget här just nu, men kommer inom snart!");
                        hero.ShowEquippedItems();
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        hero.ManageInventory();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Det finns inget här för tillfället. Mer kommer inom kort!");
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Clear();
                        healing._Healing();
                        break;

                    case 6:
                        Console.Clear();
                        dungeon.EnterDungeon(GameState.CurrentHero);
                        break;

                    case 7:
                        Console.Clear();
                        Save.SaveHeroes(GameState.CurrentHero, "Hero_save.json");
                        hero.Stats();
                        Console.ReadKey();
                        break;

                    case 8:
                        Console.Clear();
                        Console.WriteLine("Kommmer ngt inom kort");
                        break;

                    case 9:
                        Console.Clear();
                        Console.WriteLine("Tack för att du använder detta programmet, nu avslutas programmet");
                        spel = false;
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val, försök med bokstäverna innanför []");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}


