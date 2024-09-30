using Kod_till_Spel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kod_till_Spel;
public class Menu
{
    public void StartMenu()
    {
        Load load1 = new Load();
        Colour colour = new Colour();
        Hero hero = new Hero();
        bool load = true;
        while (load)
        {
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
                        hero = loadedHeroes[selectedHeroIndex - 1];
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
                }
                Console.ReadKey();
                break;
            }
            else if (choice.ToUpper() == "N")
            {
                Console.Write("Ange ett namn till din Hjälte: ");
                hero.name = Console.ReadLine();
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


        bool spel = true;
        while (spel)
        {
            Console.Clear();
            Console.WriteLine("\n=== TEXT SPEL ===          A game created by #Christofer Hägg");
            Console.WriteLine("1. för att kolla Status på din hjälte");
            Console.WriteLine("2. för att Attackera mobs");
            Console.WriteLine("3. för att kolla utrustade föremål");
            Console.WriteLine("4. för att kolla hittade föremål");
            Console.WriteLine("5. för att gå in i Shopen");
            Console.WriteLine("6. för att Meditera (Heala din hjälte)");
            Console.WriteLine("7. för att gå till Dungeons");
            Console.WriteLine("8. för att Spara din hjälte");
            Console.WriteLine("9. för att Ladda en hjälte");
            Console.WriteLine("10. för att stänga programmet");
            Console.Write("Val: ");
            string val = Console.ReadLine();
            Console.Clear();

            switch (val)
            {
                case "1":
                    Console.WriteLine("===================================");
                    Console.WriteLine($"Ditt namn på din Hero: {hero.name}\n");
                    Console.WriteLine("Din hjälte är på Level: " + hero.level);
                    Console.WriteLine($"Din hjälte har: {hero.experience}xp");
                    Console.WriteLine($"Din hjälte har: {hero.maxXp - hero.experience}xp kvar till nästa level\n");
                    Console.WriteLine($"Du har för närvarande {hero.Guld} guld\n");
                    Console.Write($"HP: ");
                    if (hero.hp < hero.maxHp)
                    {
                        Red(hero.hp);
                    }
                    else
                    {
                        Green(hero.hp);
                    }
                    Console.Write(hero.hp);
                    Console.ResetColor();
                    Console.Write(" av ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(hero.maxHp);
                    Console.ResetColor();
                    Console.WriteLine("Styrka: " + hero.styrka);
                    Console.WriteLine("Agility: " + hero.agility);
                    Console.WriteLine("Stamina: " + hero.stamina);
                    Console.WriteLine("Intelligence: " + hero.intelligence);
                    Console.WriteLine("Charm: " + hero.charm);
                    Console.WriteLine("Speed: " + hero.speed);
                    Console.WriteLine("DMG: " + hero.dmg);
                    Console.WriteLine("ARMOR: " + hero.armor);
                    Console.WriteLine($"LifeSteal: {hero.lifeSteal}");
                    Console.WriteLine("===================================");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case "2":
                    attack._Attack(hero);
                    break;
                case "3":
                    //Console.WriteLine("Finns inget här just nu, men kommer inom snart!");
                    hero.ShowEquippedItems();
                    Console.ReadKey();
                    break;

                case "4":

                    hero.ManageInventory();
                    break;

                case "5":
                    Console.WriteLine("Det finns inget här för tillfället. Mer kommer inom kort!");
                    Console.ReadKey();
                    break;


                case "6":
                    healing._Healing(hero);
                    break;

                case "7":
                    dungeon.EnterDungeon();
                    break;

                case "8":
                    Save.SaveHeroes(hero, "Hero_save.json");
                    hero.Stats();
                    Console.ReadKey();
                    break;

                case "9":
                    Console.WriteLine("Kommmer ngt inom kort");
                    break;

                case "10":
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
static void Green(int value)
{
    Console.ForegroundColor = ConsoleColor.Green;
}
static void Red(int value)
{
    Console.ForegroundColor = ConsoleColor.Red;
}
}


