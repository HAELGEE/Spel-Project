using System;
using System.Runtime.InteropServices;
using Kod_till_Spel;
using System.IO;
using System.Text.Json;


namespace SPEL
{
    public class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero();
            bool load = true;
            while (load)
            {
                Console.WriteLine("Vill du ladda en hjälte? J/N");
                string choice = Console.ReadLine();
                if (choice.ToUpper() == "J")
                {
                    Hero loadedHero = LoadHero("hero_save.json");
                    if (loadedHero != null)
                    {
                        hero = loadedHero;
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
                    Console.WriteLine("Invalid input");
                }
            }
            Attack attack = new Attack();
            Healing healing = new Healing();
            
            Dungeons dungeon = new Dungeons(hero);


            bool spel = true;
            while (spel)
            {
                Console.Clear();
                Console.WriteLine("\n=== TEXT SPEL ===          A game created by #Christofer Hägg");
                Console.WriteLine("[S]tatus");
                Console.WriteLine("[I]tems");
                Console.WriteLine("[Equip]");
                Console.WriteLine("[Shop]");
                Console.WriteLine("[A]ttack");
                Console.WriteLine("[H]eal");
                Console.WriteLine("Sa[V]e");
                Console.WriteLine("[D]ungeon");
                Console.WriteLine("[Quit]");
                Console.Write("Val: ");
                string val = Console.ReadLine().ToLower();
                Console.Clear();

                switch (val)
                {
                    case "s":
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

                    case "i":
                        Console.WriteLine("Finns inget här just nu, men kommer inom snart!");
                        //hero.ShowItems();
                        Console.ReadKey();
                        break;

                    case "equip":
                        
                        Console.WriteLine("Mer kommer inom kort");
                        Console.ReadKey();
                        break;

                    case "shop":
                        Console.WriteLine("Det finns inget här för tillfället. Mer kommer inom kort!");
                        Console.ReadKey();
                        break;

                    case "a":
                        attack._Attack(hero);
                        break;

                    case "h":
                        healing._Healing(hero);
                        break;

                    case "v":

                        SaveHero(hero, "hero_save.json");
                        hero.Stats();
                        Console.ReadKey();
                        break;

                    case "d":
                        dungeon.EnterDungeon();
                        break;

                    case "quit":
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
        public static void SaveHero(Hero hero, string filename)
        {
            string json = JsonSerializer.Serialize(hero);
            File.WriteAllText(filename, json);
            Console.WriteLine("Hjälten är nu sparad.");
        }
        public static Hero LoadHero(string filename)
        {
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                Hero hero = JsonSerializer.Deserialize<Hero>(json);
                Console.WriteLine("Hjälten är nu laddad.");
                return hero;
            }
            else
            {
                Console.WriteLine("Ingen sparfil hittades.");
                return null;
            }
        }
    }
}
